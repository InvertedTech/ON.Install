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
    public class ProgressService : StatsProgressInterface.StatsProgressInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IProgressDataProvider dataProvider;

        public ProgressService(ILogger<ProgressService> logger, IProgressDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        public override async Task<LogProgressContentResponse> LogProgressContent(LogProgressContentRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new() { Error = "ContentID not valid Guid." };
            if (request.Progress < 0 || request.Progress > 1)
                return new() { Error = "Progress must be between 0 and 1." };

            await dataProvider.LogProgress(userToken?.Id ?? Guid.Empty, contentId, request.Progress);

            return new();
        }
    }
}
