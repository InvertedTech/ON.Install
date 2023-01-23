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
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.SimpleCMS.Service
{
    [Authorize]
    public class ContentService : ContentInterface.ContentInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IContentDataProvider dataProvider;
        //private readonly StatsClient statsClient;

        public ContentService(ILogger<ContentService> logger, IContentDataProvider dataProvider/*, StatsClient statsClient*/)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
            //this.statsClient = statsClient;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<AnnounceContentResponse> AnnounceContent(AnnounceContentRequest request, ServerCallContext context)
        {
            if (request.AnnounceOnUTC == null)
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.AnnounceOnUTC = request.AnnounceOnUTC;
            record.Private.AnnouncedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<CreateContentResponse> CreateContent(CreateContentRequest request, ServerCallContext context)
        {
            if (!IsValid(request.Public, request.Private))
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var record = new ContentRecord
            {
                Public = new()
                {
                    ContentID = Guid.NewGuid().ToString(),
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
        public override async Task<DeleteContentResponse> DeleteContent(DeleteContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [AllowAnonymous]
        public override async Task<GetAllContentResponse> GetAllContent(GetAllContentRequest request, ServerCallContext context)
        {
            var possiblyIDs = request.PossibleContentIDs.ToList();
            var searchCatId = request.CategoryId;
            var searchChanId = request.ChannelId;
            var searchAuthorId = request.AuthorId;
            var searchTag = request.Tag;
            var searchLiveOnly = request.OnlyLive;

            if (!possiblyIDs.Any())
                possiblyIDs = null;
            if (string.IsNullOrWhiteSpace(searchCatId))
                searchCatId = null;
            if (string.IsNullOrWhiteSpace(searchChanId))
                searchChanId = null;
            if (string.IsNullOrWhiteSpace(searchAuthorId))
                searchAuthorId = null;
            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new GetAllContentResponse();

            List<ContentListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (!CanShowInList(rec, null))
                    continue;

                if (possiblyIDs != null)
                    if (!possiblyIDs.Contains(rec.Public.ContentID))
                        continue;

                if (request.SubscriptionSearch != null)
                {
                    if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
                        continue;
                    if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
                        continue;
                }

                if (searchCatId != null)
                    if (!rec.Public.Data.CategoryIds.Contains(searchCatId))
                        continue;

                if (searchChanId != null)
                    if (!rec.Public.Data.ChannelIds.Contains(searchChanId))
                        continue;

                if (searchAuthorId != null)
                    if (rec.Public.Data.AuthorID != searchAuthorId)
                        continue;

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                if (searchLiveOnly)
                    if (!(rec.Public.Data.Video?.IsLive ?? false))
                        continue;

                var listRec = rec.Public.ToContentListRecord();

                if (request.ContentType != ContentType.None)
                {
                    if (listRec.ContentType != request.ContentType)
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

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<GetAllContentAdminResponse> GetAllContentAdmin(GetAllContentAdminRequest request, ServerCallContext context)
        {
            var possiblyIDs = request.PossibleContentIDs.ToList();
            var searchCatId = request.CategoryId;
            var searchChanId = request.ChannelId;
            var searchTag = request.Tag;
            var searchLiveOnly = request.OnlyLive;

            if (!possiblyIDs.Any())
                possiblyIDs = null;
            if (string.IsNullOrWhiteSpace(searchCatId))
                searchCatId = null;
            if (string.IsNullOrWhiteSpace(searchChanId))
                searchChanId = null;
            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new GetAllContentAdminResponse();

            List<ContentListRecord> list = new();
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
                    if (!possiblyIDs.Contains(rec.Public.ContentID))
                        continue;

                if (request.SubscriptionSearch != null)
                {
                    if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
                        continue;
                    if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
                        continue;
                }

                if (searchCatId != null)
                    if (!rec.Public.Data.CategoryIds.Contains(searchCatId))
                        continue;

                if (searchChanId != null)
                    if (!rec.Public.Data.ChannelIds.Contains(searchChanId))
                        continue;

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                if (searchLiveOnly)
                    if (!(rec.Public.Data.Video?.IsLive ?? false))
                        continue;

                var listRec = rec.Public.ToContentListRecord();

                if (request.ContentType != ContentType.None)
                {
                    if (listRec.ContentType != request.ContentType)
                        continue;
                }

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
        public override async Task<GetContentResponse> GetContent(GetContentRequest request, ServerCallContext context)
        {
            try
            {
                var user = ONUserHelper.ParseUser(context.GetHttpContext());

                Guid contentId = request.ContentID.ToGuid();
                if (contentId == Guid.Empty)
                    return new GetContentResponse();

                var rec = await dataProvider.GetById(contentId);
                if (rec == null)
                    return new();

                if (!CanShowInList(rec, user))
                    return new();

                if (!CanShowContent(rec, user))
                    ClearPublicData(rec.Public.Data);

                //await statsClient.RecordView(contentId, user);

                return new() { Record = rec.Public };
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error trying to GetContent");
            }

            return new();
        }

        [AllowAnonymous]
        public override async Task<GetContentByUrlResponse> GetContentByUrl(GetContentByUrlRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            string contentUrl = request.ContentUrl;
            if (string.IsNullOrWhiteSpace(contentUrl))
                return new();

            var rec = await dataProvider.GetByURL(contentUrl);
            if (rec == null)
                return new();

            if (!CanShowInList(rec, user))
                return new();

            if (!CanShowContent(rec, user))
                ClearPublicData(rec.Public.Data);

            return new() { Record = rec.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<GetContentAdminResponse> GetContentAdmin(GetContentAdminRequest request, ServerCallContext context)
        {
            Guid contentId = request.ContentID.ToGuid();
            if (contentId == Guid.Empty)
                return new();

            var rec = await dataProvider.GetById(contentId);
            if (rec == null)
                return new();

            return new() { Record = rec };
        }

        [AllowAnonymous]
        public override async Task<GetRecentTagsResponse> GetRecentTags(GetRecentTagsRequest request, ServerCallContext context)
        {
            int num = Math.Min((int)request.NumTags, 100);

            List<string> allTags = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                allTags.AddRange(rec.Public.Data.Tags.Where(t => !allTags.Contains(t)));
                if (allTags.Count > num)
                    break;
            }

            var res = new GetRecentTagsResponse();
            res.Tags.AddRange(allTags.Take(num));
            return res;
        }

        [AllowAnonymous]
        public override async Task<GetRelatedContentResponse> GetRelatedContent(GetRelatedContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            Guid contentId = request.ContentID.ToGuid();
            if (contentId == Guid.Empty)
                return new ();

            var curRec = await dataProvider.GetById(contentId);
            if (curRec == null)
                return new();

            if (!CanShowInList(curRec, user))
                return new();

            var res = new GetRelatedContentResponse();

            List<ContentListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (!CanShowInList(rec, null))
                    continue;

                if (rec.Public.ContentID == request.ContentID)
                    continue;

                var listRec = rec.Public.ToContentListRecord();

                if (curRec.Public.Data.GetContentType() != ContentType.None)
                {
                    if (listRec.ContentType != curRec.Public.Data.GetContentType())
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

        [Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        public override async Task<ModifyContentResponse> ModifyContent(ModifyContentRequest request, ServerCallContext context)
        {
            if (!IsValid(request.Public, request.Private))
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
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
        public override async Task<PublishContentResponse> PublishContent(PublishContentRequest request, ServerCallContext context)
        {
            if (request.PublishOnUTC == null)
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.PublishOnUTC = request.PublishOnUTC;
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [AllowAnonymous]
        public override async Task<SearchContentResponse> SearchContent(SearchContentRequest request, ServerCallContext context)
        {
            var searchQueryBits = Array.Empty<string>();
            var searchCatId = request.CategoryId;
            var searchChanId = request.ChannelId;
            var searchTag = request.Tag;
            var searchLiveOnly = request.OnlyLive;

            if (!string.IsNullOrWhiteSpace(request.Query))
                searchQueryBits = request.Query.ToLower().Replace("\"", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            if (string.IsNullOrWhiteSpace(searchCatId))
                searchCatId = null;
            if (string.IsNullOrWhiteSpace(searchChanId))
                searchChanId = null;
            if (string.IsNullOrWhiteSpace(searchTag))
                searchTag = null;

            var res = new SearchContentResponse();

            List<ContentListRecord> list = new();
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

                if (searchCatId != null)
                    if (!rec.Public.Data.CategoryIds.Contains(searchCatId))
                        continue;

                if (searchChanId != null)
                    if (!rec.Public.Data.ChannelIds.Contains(searchChanId))
                        continue;

                if (searchTag != null)
                    if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
                        continue;

                if (searchLiveOnly)
                    if (!(rec.Public.Data.Video?.IsLive ?? false))
                        continue;

                var listRec = rec.Public.ToContentListRecord();

                if (request.ContentType != ContentType.None)
                {
                    if (listRec.ContentType != request.ContentType)
                        continue;
                }

                if (searchQueryBits.Length > 0)
                {
                    if (!MeetsQuery(searchQueryBits, rec))
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
        public override async Task<UnannounceContentResponse> UnannounceContent(UnannounceContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.AnnounceOnUTC = null;
            record.Private.AnnouncedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<UndeleteContentResponse> UndeleteContent(UndeleteContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = null;
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_PUBLISH)]
        public override async Task<UnpublishContentResponse> UnpublishContent(UnpublishContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new();

            record.Public.PublishOnUTC = null;
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record };
        }

        private bool CanShowContent(ContentRecord rec, ONUser user)
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

        private bool CanShowInList(ContentRecord rec, ONUser user)
        {
            if (rec.Public.DeletedOnUTC != null)
                return false;

            if (user?.CanCreateContent ?? false)
                return true;

            if (rec.Public.PublishOnUTC == null || rec.Public.PublishOnUTC > Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow))
                return false;

            return true;
        }

        private void ClearPublicData(ContentPublicData data)
        {
            switch (data.ContentDataOneofCase)
            {
                case ContentPublicData.ContentDataOneofOneofCase.Audio:
                    data.Audio.AudioAssetID = "";
                    data.Audio.HtmlBody = "";
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Picture:
                    data.Picture.HtmlBody = "";
                    data.Picture.ImageAssetIDs.Clear();
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Video:
                    data.Video.HtmlBody = "";
                    data.Video.RumbleVideoId = "";
                    data.Video.YoutubeVideoId = "";
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Written:
                    data.Written.HtmlBody = "";
                    break;
            }
        }

        private bool IsValid(ContentPublicData pubData, ContentPrivateData privData)
        {
            if (pubData == null)
                return false;
            if (privData == null)
                return false;
            if (string.IsNullOrWhiteSpace(pubData.Title))
                return false;

            switch (pubData.ContentDataOneofCase)
            {
                case ContentPublicData.ContentDataOneofOneofCase.Audio:
                    if (!IsValid(pubData.Audio, privData.Audio))
                        return false;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Picture:
                    if (!IsValid(pubData.Picture, privData.Picture))
                        return false;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Video:
                    if (!IsValid(pubData.Video, privData.Video))
                        return false;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Written:
                    if (!IsValid(pubData.Written, privData.Written))
                        return false;
                    break;
                default:
                    return false;
            }

            return true;
        }

        private bool IsValid(AudioContentPublicData pubData, AudioContentPrivateData privData)
        {
            if (privData == null)
                return false;

            if (!IsValidAssetId(pubData.AudioAssetID))
                return false;

            return true;
        }

        private bool IsValid(PictureContentPublicData pubData, PictureContentPrivateData privData)
        {
            if (privData == null)
                return false;

            if (pubData.ImageAssetIDs == null)
                return false;

            foreach (var id in pubData.ImageAssetIDs)
                if (!IsValidAssetId(id))
                    return false;

            return true;
        }

        private bool IsValid(VideoContentPublicData pubData, VideoContentPrivateData privData)
        {
            if (privData == null)
                return false;

            if (string.IsNullOrWhiteSpace(pubData.RumbleVideoId) && string.IsNullOrWhiteSpace(pubData.YoutubeVideoId))
                return false;

            return true;
        }

        private bool IsValid(WrittenContentPublicData pubData, WrittenContentPrivateData privData)
        {
            if (privData == null)
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

        private bool MeetsQuery(string[] searchQueryBits, ContentRecord rec)
        {
            if (MeetsQuery(searchQueryBits, rec.Public.Data.Title.ToLower()))
                return true;

            if (MeetsQuery(searchQueryBits, rec.Public.Data.Description.ToLower()))
                return true;

            switch (rec.Public.Data.ContentDataOneofCase)
            {
                case ContentPublicData.ContentDataOneofOneofCase.Audio:
                    if (MeetsQuery(searchQueryBits, rec.Public.Data.Audio.HtmlBody.ToLower()))
                        return true;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Picture:
                    if (MeetsQuery(searchQueryBits, rec.Public.Data.Picture.HtmlBody.ToLower()))
                        return true;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Written:
                    if (MeetsQuery(searchQueryBits, rec.Public.Data.Written.HtmlBody.ToLower()))
                        return true;
                    break;
                case ContentPublicData.ContentDataOneofOneofCase.Video:
                    if (MeetsQuery(searchQueryBits, rec.Public.Data.Video.HtmlBody.ToLower()))
                        return true;
                    break;
                default:
                    break;
            }

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
