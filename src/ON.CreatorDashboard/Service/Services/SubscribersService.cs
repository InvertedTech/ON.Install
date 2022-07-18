using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Fragments.CreatorDashboard.Subscribers;
using ON.CreatorDashboard.Service.Models;
using ON.CreatorDashboard.Service.Interfaces;

namespace ON.CreatorDashboard.Service
{
    public class SubscribersService : SubscriberInterface.SubscriberInterfaceBase
    {
        private readonly ILogger<SubscribersService> logger;
        private readonly IOptions<AppSettings> settings;
        private readonly IMuteListProvider muteListProvider;
        private readonly IBanListProvider banListProvider;

        public SubscribersService(ILogger<SubscribersService> logger, IOptions<AppSettings> settings, IMuteListProvider muteListProvider, IBanListProvider banListProvider)
        {
            this.logger = logger;
            this.settings = settings;
            this.muteListProvider = muteListProvider;
            this.banListProvider = banListProvider;
        }

        public override Task<MuteResponse> MuteSubscriber(MuteRequest req
            , ServerCallContext context)
        {
            return null;
        }

        public override Task<UnmuteResponse> UnmuteSubscriber(UnmuteRequest req, ServerCallContext context)
        {
            return null;
        }

        public override Task<BanResponse> BanSubscriber(BanRequest req, ServerCallContext context)
        {
            return null;
        }

        public override Task<UnbanResponse> UnbanSubscriber(UnbanRequest req, ServerCallContext context)
        {
            return null;
        }
    }
}
