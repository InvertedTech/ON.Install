using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ON.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ON.Settings;
using ON.Fragments.Page;
using ON.SimpleWeb.Models.Page;

namespace ON.SimpleWeb.Services
{
    public class PageService
    {
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public PageService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<PageRecord> Create(NewViewModel vm)
        {
            if (!User.CanCreateContent)
                return null;

            var req = new CreatePageRequest
            {
                Public = new()
                {
                    Title = vm.Title,
                    Description = vm.Subtitle,
                    Author = vm.Author,
                    SubscriptionLevel = vm.Level,
                    HtmlBody = vm.Body
                },
                Private = new()
                {
                }
            };

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.CreatePageAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task<IEnumerable<PageListRecord>> GetAll()
        {
            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllPagesAsync(new(), GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<PageListRecord>();
        }

        public async Task<IEnumerable<PageListRecord>> GetAllAdmin()
        {
            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllPagesAdminAsync(new(), GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<PageListRecord>();
        }

        public async Task<IEnumerable<PageListRecord>> GetAllByIds(IEnumerable<string> pageIds)
        {
            var req = new GetAllPagesRequest();
            req.PossiblePageIDs.AddRange(pageIds);

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetAllPagesAsync(req, GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<PageListRecord>();
        }

        public async Task<PagePublicRecord> Get(Guid pageId)
        {
            var req = new GetPageRequest
            {
                PageID = pageId.ToString(),
            };

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetPageAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task<PageRecord> GetAdmin(Guid pageId)
        {
            var req = new GetPageAdminRequest
            {
                PageID = pageId.ToString(),
            };

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.GetPageAdminAsync(req, GetMetadata());

            return res?.Record;
        }

        public async Task Publish(Guid pageId)
        {
            if (!User.CanPublish)
                return;

            var res = await GetAdmin(pageId);
            if (res == null)
                return;

            var req = new PublishPageRequest()
            {
                PageID = pageId.ToString(),
                PublishOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
            };

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            await client.PublishPageAsync(req, GetMetadata());
        }

        public async Task<IEnumerable<PageListRecord>> Search(string query)
        {
            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var res = await client.SearchPageAsync(new() { Query = query }, GetMetadata());

            return res?.Records?.ToList() ?? Enumerable.Empty<PageListRecord>();
        }

        public async Task Unpublish(Guid pageId)
        {
            if (!User.CanPublish)
                return;

            var res = await GetAdmin(pageId);
            if (res == null)
                return;

            var req = new UnpublishPageRequest()
            {
                PageID = pageId.ToString(),
            };

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            await client.UnpublishPageAsync(req, GetMetadata());
        }

        public async Task<PageRecord> Update(Guid pageId, EditViewModel vm)
        {
            if (!User.CanCreateContent)
                return null;

            var client = new PageInterface.PageInterfaceClient(nameHelper.ContentServiceChannel);
            var record = await GetAdmin(pageId);

            record.Public.Data.Title = vm.Title;
            record.Public.Data.Description = vm.Subtitle;
            record.Public.Data.Author = vm.Author;
            record.Public.Data.SubscriptionLevel = vm.Level;
            record.Public.Data.HtmlBody = vm.Body;

            var req = new ModifyPageRequest()
            {
                PageID = record.Public.PageID,
                Public = record.Public.Data,
                Private = record.Private.Data,
            };

            var res = await client.ModifyPageAsync(req, GetMetadata());

            return res?.Record;
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
