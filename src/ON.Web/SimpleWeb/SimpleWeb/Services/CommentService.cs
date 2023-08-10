using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ON.SimpleWeb.Models.CMS;
using ON.Settings;
using ON.SimpleWeb.Models.Comment;
using ON.Fragments.Comment;

namespace ON.SimpleWeb.Services
{
    public class CommentService
    {
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public CommentService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<CreateCommentResponse> CreateComment(AddCommentViewModel vm)
        {
            if (!User.CanCreateContent)
                return null;

            var req = new CreateCommentForContentRequest
            {
                ContentID = vm.ContentID,
                Text = vm.CommentText,
            };

            var client = new CommentInterface.CommentInterfaceClient(nameHelper.CommentServiceChannel);
            var res = await client.CreateCommentForContentAsync(req, GetMetadata());

            return res;
        }

        public async Task<IEnumerable<CommentPublicRecord>> GetAllForContent(Guid contentID)
        {
            try
            {
                var client = new CommentInterface.CommentInterfaceClient(nameHelper.CommentServiceChannel);
                var res = await client.GetCommentsForContentAsync(new() { ContentID = contentID.ToString(), Options = new() { Order = CommentOrder.Liked } }, GetMetadata());

                return res?.Records?.ToList() ?? Enumerable.Empty<CommentPublicRecord>();
            }
            catch
            {
                return Enumerable.Empty<CommentPublicRecord>();
            }
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
