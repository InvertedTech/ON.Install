using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using ON.Authentication;
using ON.Content.SimpleComment.Service.Data;
using ON.Content.SimpleComment.Service.Helper;
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
        private readonly UserDataHelper userDataHelper;
        private readonly SettingsClient settings;
        private readonly CommentRestrictionMinimum commentRestrictionMinimum;

        public CommentService(ILogger<CommentService> logger, ICommentDataProvider dataProvider, UserDataHelper userDataHelper, SettingsClient settings)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.userDataHelper = userDataHelper;
            this.settings = settings;

            commentRestrictionMinimum = settings.PublicData.Comments.DefaultRestriction;
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminDeleteCommentResponse> AdminDeleteComment(AdminDeleteCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminEditCommentResponse> AdminEditComment(AdminEditCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            record.Public.Data.CommentText = CleanText(request.Text);

            record.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.ModifiedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminPinCommentResponse> AdminPinComment(AdminPinCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            record.Public.PinnedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.PinnedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminUnDeleteCommentResponse> AdminUnDeleteComment(AdminUnDeleteCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            record.Public.DeletedOnUTC = null;
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize(Roles = ONUser.ROLE_CAN_MODERATE_COMMENT)]
        public override async Task<AdminUnPinCommentResponse> AdminUnPinComment(AdminUnPinCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            record.Public.PinnedOnUTC = null;
            record.Private.PinnedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [AllowAnonymous]
        public override async Task<CreateCommentResponse> CreateCommentForContent(CreateCommentForContentRequest request, ServerCallContext context)
        {
            var contentId = request.ContentID.ToGuid();
            if (contentId == Guid.Empty)
                return new();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
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
                    ParentCommentID = "",
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


            await dataProvider.Insert(record);

            return new() { Record = record.Public };
        }

        [AllowAnonymous]
        public override async Task<CreateCommentResponse> CreateCommentForComment(CreateCommentForCommentRequest request, ServerCallContext context)
        {
            var parentId = request.ParentCommentID.ToGuid();
            var parent = await dataProvider.Get(parentId);
            if (parent == null)
                return new ();

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
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
                    ParentCommentID = parent.Public.CommentID,
                    ContentID = parent.Public.ContentID,
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


            await dataProvider.Insert(record);

            return new() { Record = record.Public };
        }

        [Authorize]
        public override async Task<DeleteOwnCommentResponse> DeleteOwnComment(DeleteOwnCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            if (record.Public.UserID != user.Id.ToString())
                return new();

            record.Public.DeletedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.DeletedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize]
        public override async Task<EditCommentResponse> EditComment(EditCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            if (record.Public.UserID != user.Id.ToString())
                return new();

            var text = CleanText(request.Text).Trim();
            if (text.Length == 0)
                return new();

            record.Public.Data.CommentText = text;
            record.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.ModifiedBy = user.Id.ToString();

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [AllowAnonymous]
        public override async Task<GetCommentsResponse> GetCommentsForContent(GetCommentsForContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            var contentId = request.ContentID.ToGuid();

            List<CommentResponseRecord> targetList = new();
            Dictionary<string, uint> childList = new();
            var results = dataProvider.GetByContentId(contentId);
            await foreach (var rec in results)
            {
                if (!CanShowInList(rec, user)) continue;

                if (string.IsNullOrEmpty(rec.Public.ParentCommentID))
                {
                    var converted = ToCommentResponseRecord(rec, user);
                    targetList.Add(converted);
                    continue;
                }

                var key = rec.Public.ParentCommentID;
                if (childList.TryGetValue(key, out uint value))
                    childList[key] = value + 1;
                else
                    childList[key] = 1;
            }

            foreach(var rec in targetList)
            {
                if (childList.TryGetValue(rec.CommentID, out uint value))
                    rec.NumReplies = value;
            }

            return FilterResults(targetList, request.Order, request.PageSize, request.PageOffset, user);
        }

        [AllowAnonymous]
        public override async Task<GetCommentsResponse> GetCommentsForComment(GetCommentsForCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            var parentId = request.ParentCommentID.ToGuid();

            var parentRecord = await dataProvider.Get(parentId);
            if (!CanShowInList(parentRecord, user))
                return new();

            List<CommentResponseRecord> targetList = new();
            var results = dataProvider.GetByParentId(parentId);
            await foreach (var rec in results)
            {
                if (!CanShowInList(rec, user)) continue;

                    var converted = ToCommentResponseRecord(rec, user);
                    targetList.Add(converted);
            }

            var res = FilterResults(targetList, request.Order, request.PageSize, request.PageOffset, user);
            res.Parent = ToCommentResponseRecord(parentRecord, user);
            res.Parent.NumReplies = (uint)res.Records.Count;

            return res;
        }

        private GetCommentsResponse FilterResults(List<CommentResponseRecord> list, CommentOrder order, uint pageSize, uint pageOffset, ONUser user)
        {
            GetCommentsResponse res = new GetCommentsResponse();

            switch (order)
            {
                case CommentOrder.Liked:
                    res.Records.AddRange(list.OrderByDescending(r => r.CreatedOnUTC).OrderByDescending(r => r.Likes).OrderByDescending(r => r.PinnedOnUTC));
                    break;
                case CommentOrder.Newest:
                    res.Records.AddRange(list.OrderByDescending(r => r.CreatedOnUTC).OrderByDescending(r => r.PinnedOnUTC));
                    break;
                case CommentOrder.Older:
                    res.Records.AddRange(list.OrderBy(r => r.CreatedOnUTC).OrderByDescending(r => r.PinnedOnUTC));
                    break;
            }

            res.PageTotalItems = (uint)res.Records.Count;

            if (pageSize > 0)
            {
                res.PageOffsetStart = pageOffset;

                var page = res.Records.Skip((int)pageOffset).Take((int)pageSize).ToList();
                res.Records.Clear();
                res.Records.AddRange(page);
            }

            res.PageOffsetEnd = res.PageOffsetStart + (uint)res.Records.Count;

            return res;
        }

        [Authorize]
        public override async Task<LikeCommentResponse> LikeComment(LikeCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            var userId = user.Id.ToString();
            if (record.Private.Data.LikedByUserIDs.Contains(userId))
                return new() { Record = record.Public };

            record.Private.Data.LikedByUserIDs.Add(userId);
            record.Public.Data.Likes = (uint)record.Private.Data.LikedByUserIDs.Count;

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        [Authorize]
        public override async Task<UnLikeCommentResponse> UnLikeComment(UnLikeCommentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new();

            var commentId = request.CommentID.ToGuid();
            var record = await dataProvider.Get(commentId);
            if (record == null)
                return new();

            var userId = user.Id.ToString();
            if (!record.Private.Data.LikedByUserIDs.Contains(userId))
                return new() { Record = record.Public };

            record.Private.Data.LikedByUserIDs.Remove(userId);
            record.Public.Data.Likes = (uint)record.Private.Data.LikedByUserIDs.Count;

            await dataProvider.Update(record);

            return new() { Record = record.Public };
        }

        private bool CanShowInList(CommentRecord rec, ONUser user)
        {
            //if (user?.IsCommentModeratorOrHigher == true)
            //    return true;

            return rec.Public.DeletedOnUTC == null;
        }

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
                return string.Empty;
            }
        }

        private bool CanCreateComment(ONUser user)
        {
            if (user?.IsAdminOrHigher == true)
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

        private CommentResponseRecord ToCommentResponseRecord(CommentRecord r, ONUser user)
        {
            var record = new CommentResponseRecord
            {
                ContentID = r.Public.ContentID,
                CommentID = r.Public.CommentID,
                CommentText = r.Public.Data.CommentText,
                CreatedOnUTC = r.Public.CreatedOnUTC,
                ModifiedOnUTC = r.Public.ModifiedOnUTC,
                PinnedOnUTC = r.Public.PinnedOnUTC,
                UserID = r.Public.UserID,
                UserDisplayName = userDataHelper.GetRecord(r.Public.UserID).DisplayName,
                Likes = r.Public.Data.Likes,
                LikedByUser = r.Private.Data.LikedByUserIDs.Contains(user.Id.ToString()),
                NumReplies = 0,
            };

            return record;
        }

        private List<CommentResponseRecord> ToCommentResponseRecord(IOrderedEnumerable<CommentRecord> recordsIn, ONUser user)
        {
            var records = recordsIn.Select(r => ToCommentResponseRecord(r, user)).ToList();

            return records;
        }
    }
}
