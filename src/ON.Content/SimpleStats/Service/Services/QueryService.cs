using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Content.SimpleStats.Service.Data;
using ON.Fragments.Content.Stats;
using System;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Services
{
    [Authorize()]
    public class QueryService : StatsQueryInterface.StatsQueryInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IStatsContentPublicDataProvider cPubDb;
        private readonly IStatsContentPrivateDataProvider cPrvDb;
        private readonly IStatsUserPublicDataProvider uPubDb;
        private readonly IStatsUserPrivateDataProvider uPrvDb;

        public QueryService(ILogger<LikeService> logger, IStatsContentPublicDataProvider cPubDb, IStatsContentPrivateDataProvider cPrvDb, IStatsUserPublicDataProvider uPubDb, IStatsUserPrivateDataProvider uPrvDb)
        {
            this.logger = logger;
            this.cPubDb = cPubDb;
            this.cPrvDb = cPrvDb;
            this.uPubDb = uPubDb;
            this.uPrvDb = uPrvDb;
        }

        [AllowAnonymous]
        public override async Task<GetContentStatsResponse> GetContentStats(GetContentStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            bool isLiked = false, isSaved = false, isViewed = false;
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken != null && userToken.IsLoggedIn)
            {
                var userRecord = await uPrvDb.GetById(userToken.Id);
                if (userRecord != null)
                {
                    isLiked = userRecord.Likes.Contains(request.ContentID);
                    isSaved = userRecord.Saves.Contains(request.ContentID);
                    isViewed = userRecord.Views.Contains(request.ContentID);
                }
            }

            return new()
            {
                Record = await cPubDb.GetById(contentId),
                LikedByUser = isLiked,
                SavedByUser = isSaved,
                ViewedByUser = isViewed,
            };
        }

        [AllowAnonymous]
        public override async Task<GetOtherUserStatsResponse> GetOtherUserStats(GetOtherUserStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.UserID, out var userId))
                return new();

            return new()
            {
                Record = await uPubDb.GetById(userId)
            };
        }

        public override async Task<GetOwnUserLikesResponse> GetOwnUserLikes(GetOwnUserLikesRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsLoggedIn)
                return new();

            var record = await uPrvDb.GetById(userToken.Id);

            var ret = new GetOwnUserLikesResponse();
            ret.LikedContentIDs.AddRange(record.Likes);

            return ret;
        }

        public override async Task<GetOwnUserSavesResponse> GetOwnUserSaves(GetOwnUserSavesRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsLoggedIn)
                return new();

            var record = await uPrvDb.GetById(userToken.Id);

            var ret = new GetOwnUserSavesResponse();
            ret.SavedContentIDs.AddRange(record.Saves);

            return ret;
        }

        public override async Task<GetOwnUserStatsResponse> GetOwnUserStats(GetOwnUserStatsRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsLoggedIn)
                return new();

            return new()
            {
                Record = await uPubDb.GetById(userToken.Id)
            };
        }
    }
}
