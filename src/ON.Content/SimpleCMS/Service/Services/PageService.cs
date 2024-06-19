using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Content.SimpleCMS.Service.Helpers;
using ON.Fragments.Page;
using ON.Fragments.Generic;

namespace ON.Content.SimpleCMS.Service
{
    [Authorize]
    public class PageService : PageInterface.PageInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IPageDataProvider dataProvider;
        //private readonly StatsClient statsClient;

        public PageService(ILogger<PageService> logger, IPageDataProvider dataProvider/*, StatsClient statsClient*/)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
            //this.statsClient = statsClient;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<CreatePageResponse> CreatePage(CreatePageRequest request, ServerCallContext context)
        {
            if (!IsValid(request.Public, request.Private))
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var record = new PageRecord
            {
                Public = new()
                {
                    PageID = Guid.NewGuid().ToString(),
                    CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                    Data = request.Public,
                },
                Private = new()
                {
                    CreatedBy = user.Id.ToString(),
                    Data = request.Private,
                },
            };

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<DeletePageResponse> DeletePage(DeletePageRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var pageId = request.PageID.ToGuid();
            var record = await dataProvider.GetById(pageId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [AllowAnonymous]
        public override async Task<GetAllPagesResponse> GetAllPages(GetAllPagesRequest request, ServerCallContext context)
        {
            var possiblyIDs = request.PossiblePageIDs.ToList();
            var searchAuthorId = request.AuthorId;
            var searchTag = request.Tag;
            var searchPublishedAfterUTC = request.PublishedAfterUTC;
            var searchPublishedBeforeUTC = request.PublishedBeforeUTC;

            if (!possiblyIDs.Any())
                possiblyIDs = null;
            if (string.IsNullOrWhiteSpace(searchAuthorId))
                searchAuthorId = null;
            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new GetAllPagesResponse();

            List<PageListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (!CanShowInList(rec, null))
                    continue;

                if (possiblyIDs != null)
                    if (!possiblyIDs.Contains(rec.Public.PageID))
                        continue;

                if (request.SubscriptionSearch != null)
                {
                    if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
                        continue;
                    if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
                        continue;
                }

                if (searchAuthorId != null)
                    if (rec.Public.Data.AuthorID != searchAuthorId)
                        continue;

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                if (searchPublishedAfterUTC != null)
                    if (rec.Public.PublishOnUTC < searchPublishedAfterUTC)
                        continue;

                if (searchPublishedBeforeUTC != null)
                    if (rec.Public.PublishOnUTC > searchPublishedBeforeUTC)
                        continue;

                var listRec = rec.Public.ToPageListRecord();

                list.Add(listRec);
            }

            res.Records.AddRange(list.OrderByDescending(r => r.PublishOnUTC).OrderByDescending(r=>r.PinnedOnUTC));
            res.PageTotalItems = (uint)res.Records.Count;

            if (request.PageSize > 0)
            {
                res.PageOffsetStart = request.PageOffset;

                var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
                res.Records.Clear();
                res.Records.AddRange(page);
            }

            res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

            return res;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<GetAllPagesAdminResponse> GetAllPagesAdmin(GetAllPagesAdminRequest request, ServerCallContext context)
        {
            var possiblyIDs = request.PossiblePageIDs.ToList();
            var searchTag = request.Tag;

            if (!possiblyIDs.Any())
                possiblyIDs = null;
            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new GetAllPagesAdminResponse();

            List<PageListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (request.Deleted)
                {
                    if (rec.Public.DeletedOnUTC == null)
                        continue;
                }
                else
                {
                    if (rec.Public.DeletedOnUTC != null)
                        continue;
                }

                if (possiblyIDs != null)
                    if (!possiblyIDs.Contains(rec.Public.PageID))
                        continue;

                if (request.SubscriptionSearch != null)
                {
                    if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
                        continue;
                    if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
                        continue;
                }

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                var listRec = rec.Public.ToPageListRecord();

                list.Add(listRec);
            }

            res.Records.AddRange(list.OrderByDescending(r => r.CreatedOnUTC));
            res.PageTotalItems = (uint)res.Records.Count;

            if (request.PageSize > 0)
            {
                res.PageOffsetStart = request.PageOffset;

                var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
                res.Records.Clear();
                res.Records.AddRange(page);
            }

            res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

            return res;
        }

        [AllowAnonymous]
        public override async Task<GetPageResponse> GetPage(GetPageRequest request, ServerCallContext context)
        {
            try
            {
                var user = ONUserHelper.ParseUser(context.GetHttpContext());

                Guid pageId = request.PageID.ToGuid();
                if (pageId == Guid.Empty)
                    return new GetPageResponse();

                var rec = await dataProvider.GetById(pageId);
                if (rec == null)
                    return new();

                if (!CanShowInList(rec, user))
                    return new();

                if (!CanShowPage(rec, user))
                    ClearPublicData(rec.Public.Data);

                //await statsClient.RecordView(pageId, user);

                return new() { Record = rec.Public };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error trying to GetPage");
            }

            return new();
        }

        [AllowAnonymous]
        public override async Task<GetPageByUrlResponse> GetPageByUrl(GetPageByUrlRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            string pageUrl = request.PageUrl;
            if (string.IsNullOrWhiteSpace(pageUrl))
                return new();

            var rec = await dataProvider.GetByURL(pageUrl);
            if (rec == null)
                return new();

            if (!CanShowInList(rec, user))
                return new();

            if (!CanShowPage(rec, user))
                ClearPublicData(rec.Public.Data);

            return new() { Record = rec.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<GetPageAdminResponse> GetPageAdmin(GetPageAdminRequest request, ServerCallContext context)
        {
            Guid pageId = request.PageID.ToGuid();
            if (pageId == Guid.Empty)
                return new();

            var rec = await dataProvider.GetById(pageId);
            if (rec == null)
                return new();

            return new() { Record = rec };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<ModifyPageResponse> ModifyPage(ModifyPageRequest request, ServerCallContext context)
        {
            if (!IsValid(request.Public, request.Private))
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var pageId = request.PageID.ToGuid();
            var record = await dataProvider.GetById(pageId);
            if (record == null)
                return new();

            record.Public.Data = request.Public;
            record.Private.Data = request.Private;
            record.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.ModifiedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<PublishPageResponse> PublishPage(PublishPageRequest request, ServerCallContext context)
        {
            if (request.PublishOnUTC == null)
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var pageId = request.PageID.ToGuid();
            var record = await dataProvider.GetById(pageId);
            if (record == null)
                return new();

            record.Public.PublishOnUTC = request.PublishOnUTC;
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [AllowAnonymous]
        public override async Task<SearchPageResponse> SearchPage(SearchPageRequest request, ServerCallContext context)
        {
            var searchQueryBits = Array.Empty<string>();
            var searchTag = request.Tag;

            if (!string.IsNullOrWhiteSpace(request.Query))
                searchQueryBits = request.Query.ToLower().Replace("\"", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new SearchPageResponse();

            List<PageListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (!CanShowInList(rec, null))
                    continue;

                if (request.SubscriptionSearch != null)
                {
                    if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
                        continue;
                    if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
                        continue;
                }

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                var listRec = rec.Public.ToPageListRecord();

                if (searchQueryBits.Length > 0)
                {
                    if (!MeetsQuery(searchQueryBits, request.Query, rec))
                        continue;
                }

                list.Add(listRec);
            }

            res.Records.AddRange(list.OrderByDescending(r => r.PublishOnUTC));
            res.PageTotalItems = (uint)res.Records.Count;

            if (request.PageSize > 0)
            {
                res.PageOffsetStart = request.PageOffset;

                var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
                res.Records.Clear();
                res.Records.AddRange(page);
            }

            res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

            return res;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<UndeletePageResponse> UndeletePage(UndeletePageRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var pageId = request.PageID.ToGuid();
            var record = await dataProvider.GetById(pageId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = null;
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<UnpublishPageResponse> UnpublishPage(UnpublishPageRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var pageId = request.PageID.ToGuid();
            var record = await dataProvider.GetById(pageId);
            if (record == null)
                return new();

            record.Public.PublishOnUTC = null;
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        private bool CanShowPage(PageRecord rec, ONUser user)
        {
            if (user?.IsWriterOrHigher ?? false)
                return true;

            if (!CanShowInList(rec, user))
                return false;

            var recLevel = rec.Public.Data.SubscriptionLevel;
            if (recLevel > (user?.SubscriptionLevel ?? 0))
                return false;

            return true;
        }

        private bool CanShowInList(PageRecord rec, ONUser user)
        {
            if (rec.Public.DeletedOnUTC != null)
                return false;

            if (user?.CanCreateContent ?? false)
                return true;

            if (rec.Public.PublishOnUTC == null || rec.Public.PublishOnUTC > Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow))
                return false;

            return true;
        }

        private void ClearPublicData(PagePublicData data)
        {
            data.HtmlBody = "";
        }

        private bool IsValid(PagePublicData pubData, PagePrivateData privData)
        {
            if (pubData == null)
                return false;
            if (privData == null)
                return false;
            if (string.IsNullOrWhiteSpace(pubData.Title))
                return false;
            if (string.IsNullOrWhiteSpace(pubData.HtmlBody))
                return false;

            return true;
        }

        public bool IsValidAssetId(string idStr)
        {
            if (string.IsNullOrWhiteSpace(idStr))
                return false;

            return true;
        }

        private bool MeetsQuery(string[] searchQueryBits, string searchQuery, PageRecord rec)
        {
            if (MeetsQuery(searchQueryBits, rec.Public.Data.Title.ToLower()))
                return true;

            if (MeetsQuery(searchQueryBits, rec.Public.Data.Description.ToLower()))
                return true;

            if (MeetsQuery(searchQueryBits, rec.Public.Data.HtmlBody.ToLower()))
                return true;

            return false;
        }

        private bool MeetsQuery(string[] searchQueryBits, string haystack)
        {
            foreach (string bit in searchQueryBits)
                if (haystack.Contains(bit))
                    return true;
            return false;
        }
    }
}
