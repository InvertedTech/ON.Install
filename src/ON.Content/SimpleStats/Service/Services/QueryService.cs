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

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<AdminGetContentStatsResponse> AdminGetContentStats(AdminGetContentStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            return new()
            {
                Record = await cPrvDb.GetById(contentId)
            };
        }

        [Authorize(Roles = ONUser.ROLE_IS_ADMIN_OR_OWNER)]
        public override async Task<AdminGetOtherUserStatsResponse> AdminGetOtherUserStats(AdminGetOtherUserStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.UserID, out var userId))
                return new();

            return new()
            {
                Record = await uPrvDb.GetById(userId)
            };
        }

        public override async Task<GetContentStatsResponse> GetContentStats(GetContentStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            return new()
            {
                Record = await cPubDb.GetById(contentId)
            };
        }

        public override async Task<GetOtherUserStatsResponse> GetOtherUserStats(GetOtherUserStatsRequest request, ServerCallContext context)
        {
            if (!Guid.TryParse(request.UserID, out var userId))
                return new();

            return new()
            {
                Record = await uPubDb.GetById(userId)
            };
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
                Record = await uPrvDb.GetById(userToken.Id)
            };
        }
    }
}
