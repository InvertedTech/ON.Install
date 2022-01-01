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

        public async Task<SaveContentResponse> CreateContent(NewViewModel vm)
        {
            var req = new SaveContentRequest
            {
                Content = new ContentRecord
                {
                    Public = new ContentRecord.Types.PublicData
                    {
                        ContentID = Google.Protobuf.ByteString.CopyFrom(Guid.NewGuid().ToByteArray()),
                        Title = vm.Title,
                        Subtitle = vm.Subtitle,
                        Author = vm.Author,
                        Body = vm.Body ?? "",
                        CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                        SubscriptionLevel = vm.Level
                    },
                    Private = new ContentRecord.Types.PrivateData
                    {
                        CreatedBy = User.Id.ToString()
                    }
                }
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.SaveContentAsync(req);

            return res;
        }

        public async Task<GetAllContentResponse> GetAll()
        {
            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllContentAsync(new());

            return res;
        }

        public async Task<GetContentResponse> GetContent(Guid contentId)
        {
            var req = new GetContentRequest
            {
                ContentID = Google.Protobuf.ByteString.CopyFrom(contentId.ToByteArray()),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetContentAsync(req);

            return res;
        }

        public async Task PublishContent(Guid contentId)
        {
            var res = await GetContent(contentId);
            var rec = res?.Content;
            if (rec == null)
                return;

            rec.Public.PublishedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            rec.Private.PublishedBy = User.Id.ToString();

            var req = new SaveContentRequest
            {
                Content = rec
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.SaveContentAsync(req);
        }

        public async Task UnpublishContent(Guid contentId)
        {
            var res = await GetContent(contentId);
            var rec = res?.Content;
            if (rec == null)
                return;

            rec.Public.PublishedOnUTC = null;
            rec.Private.PublishedBy = User.Id.ToString();

            var req = new SaveContentRequest
            {
                Content = rec
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.SaveContentAsync(req);
        }

        public async Task<SaveContentResponse> UpdateContent(ContentRecord rec)
        {
            rec.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            rec.Private.ModifiedBy = User.Id.ToString();

            var req = new SaveContentRequest
            {
                Content = rec
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.SaveContentAsync(req);

            return res;
        }
    }
}
