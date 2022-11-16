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
    public class LikeService : StatsLikeInterface.StatsLikeInterfaceBase
    {
        private readonly ILogger logger;
        private readonly ILikeDataProvider dataProvider;

        public LikeService(ILogger<LikeService> logger, ILikeDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        public override async Task<LikeContentResponse> LikeContent(LikeContentRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsLoggedIn)
                return new();

            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            await dataProvider.Like(userToken.Id, contentId);

            return new();
        }

        public override async Task<LikeContentResponse> UnlikeContent(LikeContentRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsLoggedIn)
                return new();

            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            await dataProvider.Unlike(userToken.Id, contentId);

            return new();
        }
    }
}
