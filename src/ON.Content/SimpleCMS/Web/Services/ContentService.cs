using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using ON.Authentication;
using ON.Content.SimpleCMS.Web.Helper;
using ON.Content.SimpleCMS.Web.Models;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Web.Services
{
    public class ContentService
    {
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public ContentService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<CreateContentResponse> CreateContent(NewViewModel vm)
        {
            var req = new CreateContentRequest
            {
                Title = vm.Title,
                Subtitle = vm.Subtitle,
                Author = vm.Author,
                Body = vm.Body,
                SubscriptionLevel = vm.Level,
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.CreateContentAsync(req, GetMetadata());

            return res;
        }

        public async Task<GetAllContentResponse> GetAll()
        {
            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllContentAsync(new(), GetMetadata());

            return res;
        }

        public async Task<GetContentResponse> GetContent(Guid contentId)
        {
            var req = new GetContentRequest
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetContentAsync(req, GetMetadata());

            return res;
        }

        public async Task PublishContent(Guid contentId)
        {
            if (!(User.IsAdmin || User.IsPublisher))
                return;

            var res = await GetContent(contentId);
            var rec = res?.Content;
            if (rec == null)
                return;

            var req = new PublishContentRequest()
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.PublishContentAsync(req, GetMetadata());
        }

        public async Task UnpublishContent(Guid contentId)
        {
            if (!(User.IsAdmin || User.IsPublisher))
                return;

            var res = await GetContent(contentId);
            var rec = res?.Content;
            if (rec == null)
                return;

            var req = new UnpublishContentRequest()
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.UnpublishContentAsync(req, GetMetadata());
        }

        public async Task<ModifyContentResponse> UpdateContent(Guid contentId, EditViewModel vm)
        {
            var req = new ModifyContentRequest
            {
                ContentID = contentId.ToString(),
                Title = vm.Title,
                Subtitle = vm.Subtitle,
                Author = vm.Author,
                Body = vm.Body,
                SubscriptionLevel = vm.Level,
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.ModifyContentAsync(req, GetMetadata());

            return res;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
