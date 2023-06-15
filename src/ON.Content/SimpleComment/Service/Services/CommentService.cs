using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ON.Authentication;
using ON.Content.SimpleComment.Service.Data;
using ON.Fragments.Comment;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using ON.Settings;
using static Google.Rpc.Context.AttributeContext.Types;

namespace ON.Content.SimpleComment.Service
{
    [Authorize]
    public class CommentService : CommentInterface.CommentInterfaceBase
    {
        private readonly ILogger logger;
        private readonly ICommentDataProvider dataProvider;
        private readonly SettingsClient settings;
        private readonly CommentRestrictionMinimum commentRestrictionMinimum;

        public CommentService(ILogger<CommentService> logger, ICommentDataProvider dataProvider, SettingsClient settings)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.settings = settings;

            commentRestrictionMinimum = settings.PublicData.Comments.DefaultRestriction;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminDeleteCommentResponse> AdminDeleteComment(AdminDeleteCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminEditCommentResponse> AdminEditComment(AdminEditCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            record.Public.Data.CommentText = CleanText(request.Text);

            record.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.ModifiedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminPinCommentResponse> AdminPinComment(AdminPinCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            record.Public.PinnedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.PinnedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminUnDeleteCommentResponse> AdminUnDeleteComment(AdminUnDeleteCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = null;
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminUnPinCommentResponse> AdminUnPinComment(AdminUnPinCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            record.Public.PinnedOnUTC = null;
            record.Private.PinnedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        public override Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            return CreateComment(request, user);
        }

        public override Task<CreateCommentResponse> CreateSubComment(CreateCommentRequest request, ServerCallContext context)
        {
            var parentId = request.ParentID.ToGuid();
            if (parentId == Guid.Empty)
                return Task.FromResult(new CreateCommentResponse());

            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            return CreateComment(request, user);
        }

        private async Task<CreateCommentResponse> CreateComment(CreateCommentRequest request, ONUser user)
        {
            var contentId = request.ContentID.ToGuid();
            var parentId = request.ParentID.ToGuid();

            if (contentId == Guid.Empty)
                return new();

            if (!CanCreateComment(user))
                return new();

            var text = CleanText(request.Text).Trim();
            if (text.Length == 0)
                return new();

            CommentRecord record = new()
            {
                Public = new()
                {
                    CommentID = Guid.NewGuid().ToString(),
                    ParentCommentID = parentId == Guid.Empty ? "" : parentId.ToString(),
                    ContentID = contentId.ToString(),
                    UserID = (user?.Id ?? Guid.Empty).ToString(),
                    CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                    Data = new()
                    {
                        CommentText = text,
                        Likes = 0,
                    }
                },
                Private = new()
                {
                    CreatedBy = (user?.Id ?? Guid.Empty).ToString(),
                    Data = new(),
                }
            };


            await dataProvider.Save(record);

            return new();
        }

        [Authorize]
        public override async Task<DeleteOwnCommentResponse> DeleteOwnComment(DeleteOwnCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            if (record.Public.UserID != user.Id.ToString())
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize]
        public override async Task<LikeCommentResponse> LikeComment(LikeCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            var userId = user.Id.ToString();
            if (record.Private.Data.LikedByUserIDs.Contains(userId))
                return new() { Record = record.Public };

            record.Private.Data.LikedByUserIDs.Add(userId);
            record.Public.Data.Likes = (uint)record.Private.Data.LikedByUserIDs.Count;

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        [Authorize]
        public override async Task<UnLikeCommentResponse> UnLikeComment(UnLikeCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var contentId = request.ContentID.ToGuid();
            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(contentId, commentId);
            if (record == null)
                return new();

            var userId = user.Id.ToString();
            if (!record.Private.Data.LikedByUserIDs.Contains(userId))
                return new() { Record = record.Public };

            record.Private.Data.LikedByUserIDs.Remove(userId);
            record.Public.Data.Likes = (uint)record.Private.Data.LikedByUserIDs.Count;

            await dataProvider.Save(record);

            return new() { Record = record.Public };
        }

        //[Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        //public override async Task<CreateContentResponse> CreateContent(CreateContentRequest request, ServerCallContext context)
        //{
        //    if (!IsValid(request.Public, request.Private))
        //        return new();

        //    var user = ONUserHelper.ParseUser(context.GetHttpContext());
        //    if (user == null)
        //        return new();

        //    var record = new ContentRecord
        //    {
        //        Public = new()
        //        {
        //            ContentID = Guid.NewGuid().ToString(),
        //            CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
        //            Data = request.Public,
        //        },
        //        Private = new()
        //        {
        //            CreatedBy = user.Id.ToString(),
        //            Data = request.Private,
        //        },
        //    };

        //    await dataProvider.Save(record);

        //    return new() { Record = record };
        //}

        //[AllowAnonymous]
        //public override async Task<GetAllContentResponse> GetAllContent(GetAllContentRequest request, ServerCallContext context)
        //{
        //    var possiblyIDs = request.PossibleContentIDs.ToList();
        //    var searchCatId = request.CategoryId;
        //    var searchChanId = request.ChannelId;
        //    var searchAuthorId = request.AuthorId;
        //    var searchTag = request.Tag;
        //    var searchLiveOnly = request.OnlyLive;

        //    if (!possiblyIDs.Any())
        //        possiblyIDs = null;
        //    if (string.IsNullOrWhiteSpace(searchCatId))
        //        searchCatId = null;
        //    if (string.IsNullOrWhiteSpace(searchChanId))
        //        searchChanId = null;
        //    if (string.IsNullOrWhiteSpace(searchAuthorId))
        //        searchAuthorId = null;
        //    if (string.IsNullOrWhiteSpace(searchTag))
        //        searchTag = null;

        //    var res = new GetAllContentResponse();

        //    List<ContentListRecord> list = new();
        //    await foreach (var rec in dataProvider.GetAll())
        //    {
        //        if (!CanShowInList(rec, null))
        //            continue;

        //        if (possiblyIDs != null)
        //            if (!possiblyIDs.Contains(rec.Public.ContentID))
        //                continue;

        //        if (request.SubscriptionSearch != null)
        //        {
        //            if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
        //                continue;
        //            if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
        //                continue;
        //        }

        //        if (searchCatId != null)
        //            if (!rec.Public.Data.CategoryIds.Contains(searchCatId))
        //                continue;

        //        if (searchChanId != null)
        //            if (!rec.Public.Data.ChannelIds.Contains(searchChanId))
        //                continue;

        //        if (searchAuthorId != null)
        //            if (rec.Public.Data.AuthorID != searchAuthorId)
        //                continue;

        //        if (searchTag != null)
        //            if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
        //                continue;

        //        if (searchLiveOnly)
        //            if (!(rec.Public.Data.Video?.IsLive ?? false))
        //                continue;

        //        var listRec = rec.Public.ToContentListRecord();

        //        if (request.ContentType != ContentType.None)
        //        {
        //            if (listRec.ContentType != request.ContentType)
        //                continue;
        //        }

        //        list.Add(listRec);
        //    }

        //    res.Records.AddRange(list.OrderByDescending(r => r.PublishOnUTC));
        //    res.PageTotalItems = (uint)res.Records.Count;

        //    if (request.PageSize > 0)
        //    {
        //        res.PageOffsetStart = request.PageOffset;

        //        var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
        //        res.Records.Clear();
        //        res.Records.AddRange(page);
        //    }

        //    res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

        //    return res;
        //}

        //[Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        //public override async Task<GetAllContentAdminResponse> GetAllContentAdmin(GetAllContentAdminRequest request, ServerCallContext context)
        //{
        //    var possiblyIDs = request.PossibleContentIDs.ToList();
        //    var searchCatId = request.CategoryId;
        //    var searchChanId = request.ChannelId;
        //    var searchTag = request.Tag;
        //    var searchLiveOnly = request.OnlyLive;

        //    if (!possiblyIDs.Any())
        //        possiblyIDs = null;
        //    if (string.IsNullOrWhiteSpace(searchCatId))
        //        searchCatId = null;
        //    if (string.IsNullOrWhiteSpace(searchChanId))
        //        searchChanId = null;
        //    if (string.IsNullOrWhiteSpace(searchTag))
        //        searchTag = null;

        //    var res = new GetAllContentAdminResponse();

        //    List<ContentListRecord> list = new();
        //    await foreach (var rec in dataProvider.GetAll())
        //    {
        //        if (request.Deleted)
        //        {
        //            if (rec.Public.DeletedOnUTC == null)
        //                continue;
        //        }
        //        else
        //        {
        //            if (rec.Public.DeletedOnUTC != null)
        //                continue;
        //        }

        //        if (possiblyIDs != null)
        //            if (!possiblyIDs.Contains(rec.Public.ContentID))
        //                continue;

        //        if (request.SubscriptionSearch != null)
        //        {
        //            if (rec.Public.Data.SubscriptionLevel < request.SubscriptionSearch.MinimumLevel)
        //                continue;
        //            if (rec.Public.Data.SubscriptionLevel > request.SubscriptionSearch.MaximumLevel)
        //                continue;
        //        }

        //        if (searchCatId != null)
        //            if (!rec.Public.Data.CategoryIds.Contains(searchCatId))
        //                continue;

        //        if (searchChanId != null)
        //            if (!rec.Public.Data.ChannelIds.Contains(searchChanId))
        //                continue;

        //        if (searchTag != null)
        //            if (!rec.Public.Data.Tags.Select(t => t.ToLower()).Contains(searchTag.ToLower()))
        //                continue;

        //        if (searchLiveOnly)
        //            if (!(rec.Public.Data.Video?.IsLive ?? false))
        //                continue;

        //        var listRec = rec.Public.ToContentListRecord();

        //        if (request.ContentType != ContentType.None)
        //        {
        //            if (listRec.ContentType != request.ContentType)
        //                continue;
        //        }

        //        list.Add(listRec);
        //    }

        //    res.Records.AddRange(list.OrderByDescending(r => r.CreatedOnUTC));
        //    res.PageTotalItems = (uint)res.Records.Count;

        //    if (request.PageSize > 0)
        //    {
        //        res.PageOffsetStart = request.PageOffset;

        //        var page = res.Records.Skip((int)request.PageOffset).Take((int)request.PageSize).ToList();
        //        res.Records.Clear();
        //        res.Records.AddRange(page);
        //    }

        //    res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

        //    return res;
        //}

        //[AllowAnonymous]
        //public override async Task<GetContentResponse> GetContent(GetContentRequest request, ServerCallContext context)
        //{
        //    try
        //    {
        //        var user = ONUserHelper.ParseUser(context.GetHttpContext());

        //        Guid contentId = request.ContentID.ToGuid();
        //        if (contentId == Guid.Empty)
        //            return new GetContentResponse();

        //        var rec = await dataProvider.GetById(contentId);
        //        if (rec == null)
        //            return new();

        //        if (!CanShowInList(rec, user))
        //            return new();

        //        if (!CanShowContent(rec, user))
        //            ClearPublicData(rec.Public.Data);

        //        //await statsClient.RecordView(contentId, user);

        //        return new() { Record = rec.Public };
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, "Error trying to GetContent");
        //    }

        //    return new();
        //}

        //[AllowAnonymous]
        //public override async Task<GetContentByUrlResponse> GetContentByUrl(GetContentByUrlRequest request, ServerCallContext context)
        //{
        //    var user = ONUserHelper.ParseUser(context.GetHttpContext());

        //    string contentUrl = request.ContentUrl;
        //    if (string.IsNullOrWhiteSpace(contentUrl))
        //        return new();

        //    var rec = await dataProvider.GetByURL(contentUrl);
        //    if (rec == null)
        //        return new();

        //    if (!CanShowInList(rec, user))
        //        return new();

        //    if (!CanShowContent(rec, user))
        //        ClearPublicData(rec.Public.Data);

        //    return new() { Record = rec.Public };
        //}

        //[Authorize(Roles = ONUser.ROLE_CAN_CREATE_CONTENT)]
        //public override async Task<GetContentAdminResponse> GetContentAdmin(GetContentAdminRequest request, ServerCallContext context)
        //{
        //    Guid contentId = request.ContentID.ToGuid();
        //    if (contentId == Guid.Empty)
        //        return new();

        //    var rec = await dataProvider.GetById(contentId);
        //    if (rec == null)
        //        return new();

        //    return new() { Record = rec };
        //}


        //private bool IsValid(ContentPublicData pubData, ContentPrivateData privData)
        //{
        //    if (pubData == null)
        //        return false;
        //    if (privData == null)
        //        return false;
        //    if (string.IsNullOrWhiteSpace(pubData.Title))
        //        return false;

        //    switch (pubData.ContentDataOneofCase)
        //    {
        //        case ContentPublicData.ContentDataOneofOneofCase.Audio:
        //            if (!IsValid(pubData.Audio, privData.Audio))
        //                return false;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Picture:
        //            if (!IsValid(pubData.Picture, privData.Picture))
        //                return false;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Video:
        //            if (!IsValid(pubData.Video, privData.Video))
        //                return false;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Written:
        //            if (!IsValid(pubData.Written, privData.Written))
        //                return false;
        //            break;
        //        default:
        //            return false;
        //    }

        //    return true;
        //}

        //private bool IsValid(AudioContentPublicData pubData, AudioContentPrivateData privData)
        //{
        //    if (privData == null)
        //        return false;

        //    if (!IsValidAssetId(pubData.AudioAssetID))
        //        return false;

        //    return true;
        //}

        //private bool IsValid(PictureContentPublicData pubData, PictureContentPrivateData privData)
        //{
        //    if (privData == null)
        //        return false;

        //    if (pubData.ImageAssetIDs == null)
        //        return false;

        //    foreach (var id in pubData.ImageAssetIDs)
        //        if (!IsValidAssetId(id))
        //            return false;

        //    return true;
        //}

        //private bool IsValid(VideoContentPublicData pubData, VideoContentPrivateData privData)
        //{
        //    if (privData == null)
        //        return false;

        //    if (string.IsNullOrWhiteSpace(pubData.RumbleVideoId) && string.IsNullOrWhiteSpace(pubData.YoutubeVideoId))
        //        return false;

        //    return true;
        //}

        //private bool IsValid(WrittenContentPublicData pubData, WrittenContentPrivateData privData)
        //{
        //    if (privData == null)
        //        return false;

        //    if (string.IsNullOrWhiteSpace(pubData.HtmlBody))
        //        return false;

        //    return true;
        //}

        //public bool IsValidAssetId(string idStr)
        //{
        //    if (string.IsNullOrWhiteSpace(idStr))
        //        return false;

        //    return true;
        //}

        //private bool MeetsQuery(string[] searchQueryBits, ContentRecord rec)
        //{
        //    if (MeetsQuery(searchQueryBits, rec.Public.Data.Title.ToLower()))
        //        return true;

        //    if (MeetsQuery(searchQueryBits, rec.Public.Data.Description.ToLower()))
        //        return true;

        //    switch (rec.Public.Data.ContentDataOneofCase)
        //    {
        //        case ContentPublicData.ContentDataOneofOneofCase.Audio:
        //            if (MeetsQuery(searchQueryBits, rec.Public.Data.Audio.HtmlBody.ToLower()))
        //                return true;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Picture:
        //            if (MeetsQuery(searchQueryBits, rec.Public.Data.Picture.HtmlBody.ToLower()))
        //                return true;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Written:
        //            if (MeetsQuery(searchQueryBits, rec.Public.Data.Written.HtmlBody.ToLower()))
        //                return true;
        //            break;
        //        case ContentPublicData.ContentDataOneofOneofCase.Video:
        //            if (MeetsQuery(searchQueryBits, rec.Public.Data.Video.HtmlBody.ToLower()))
        //                return true;
        //            break;
        //        default:
        //            break;
        //    }

        //    return false;
        //}

        //private bool MeetsQuery(string[] searchQueryBits, string haystack)
        //{
        //    foreach (string bit in searchQueryBits)
        //        if (haystack.Contains(bit))
        //            return true;
        //    return false;
        //}

        private string CleanText(string text)
        {
            if (text == null)
                return text;

            try
            {
                // [<>/] or @"[^\w\.@-]"
                return Regex.Replace(text, @"[<>/]", "", RegexOptions.None, TimeSpan.FromSeconds(0.5));
            }
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        private bool CanCreateComment(ONUser user)
        {
            if (user.IsAdminOrHigher)
                return true;

            switch (commentRestrictionMinimum.Minimum)
            {
                case CommentRestrictionMinimumEnum.Anonymous:
                    return true;
                case CommentRestrictionMinimumEnum.Subscriber:
                    return user?.IsLoggedIn ?? false;
                case CommentRestrictionMinimumEnum.PaidSubscriber:
                    return commentRestrictionMinimum.Level <= (user?.SubscriptionLevel ?? 0);
                case CommentRestrictionMinimumEnum.CommentModerator:
                    return user.IsCommentModeratorOrHigher;
                case CommentRestrictionMinimumEnum.AdminOnly:
                    return false;
            }

            return false;
        }
    }
}
