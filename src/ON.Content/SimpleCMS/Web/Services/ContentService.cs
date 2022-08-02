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

        public async Task<ContentRecord> CreateContent(NewViewModel vm)
        {
            if (!User.CanCreateContent)
                return null;

            var req = new CreateContentRequest
            {
                Public = new()
                {
                    Title = vm.Title,
                    Description = vm.Subtitle,
                    Author = vm.Author,
                    SubscriptionLevel = vm.Level,

                    Written = new()
                    {
                        HtmlBody = vm.Body
                    }
                },
                Private = new()
                {
                    Written = new()
                    {
                    },
                }
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.CreateContentAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task<IEnumerable<ContentListRecord>> GetAll()
        {
            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllContentAsync(new(), GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<ContentListRecord>();
        }

        public async Task<IEnumerable<ContentListRecord>> GetAllAdmin()
        {
            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllContentAdminAsync(new(), GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<ContentListRecord>();
        }

        public async Task<ContentPublicRecord> GetContent(Guid contentId)
        {
            var req = new GetContentRequest
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetContentAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task<ContentRecord> GetContentAdmin(Guid contentId)
        {
            var req = new GetContentAdminRequest
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetContentAdminAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task PublishContent(Guid contentId)
        {
            if (!User.CanPublish)
                return;

            var res = await GetContentAdmin(contentId);
            if (res == null)
                return;

            var req = new PublishContentRequest()
            {
                ContentID = contentId.ToString(),
                PublishOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.PublishContentAsync(req, GetMetadata());
        }

        public async Task UnpublishContent(Guid contentId)
        {
            if (!User.CanPublish)
                return;

            var res = await GetContentAdmin(contentId);
            if (res == null)
                return;

            var req = new UnpublishContentRequest()
            {
                ContentID = contentId.ToString(),
            };

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            await client.UnpublishContentAsync(req, GetMetadata());
        }

        public async Task<ContentRecord> UpdateContent(Guid contentId, EditViewModel vm)
        {
            if (!User.CanCreateContent)
                return null;

            var client = new ContentInterface.ContentInterfaceClient(nameHelper.ContentServiceChannel);
            var record = await GetContentAdmin(contentId);

            record.Public.Data.Title = vm.Title;
            record.Public.Data.Description = vm.Subtitle;
            record.Public.Data.Author = vm.Author;
            record.Public.Data.SubscriptionLevel = vm.Level;
            record.Public.Data.Written.HtmlBody = vm.Body;

            var req = new ModifyContentRequest()
            {
                ContentID = record.Public.ContentID,
                Public = record.Public.Data,
                Private = record.Private.Data,
            };

            var res = await client.ModifyContentAsync(req, GetMetadata());

            return res?.Record;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
