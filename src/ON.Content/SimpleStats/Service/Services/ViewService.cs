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
    [AllowAnonymous]
    public class ViewService : StatsViewInterface.StatsViewInterfaceBase
    {
        private readonly ILogger logger;
        private readonly IViewDataProvider dataProvider;

        public ViewService(ILogger<ViewService> logger, IViewDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        public override async Task<LogViewContentResponse> LogViewContent(LogViewContentRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());

            if (!Guid.TryParse(request.ContentID, out var contentId))
                return new();

            await dataProvider.LogView(userToken?.Id ?? Guid.Empty, contentId);

            return new();
        }
    }
}
