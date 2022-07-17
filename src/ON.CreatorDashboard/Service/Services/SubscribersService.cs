using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Fragments.CreatorDashboard.Subscribers;
using ON.CreatorDashboard.Service.Models;

namespace ON.CreatorDashboard.Service
{
    public class SubscribersService : SubscriberInterface.SubscriberInterfaceBase
    {
        private readonly ILogger<SubscribersService> logger;
        private readonly IOptions<AppSettings> settings;

        public SubscribersService(ILogger<SubscribersService> logger, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.settings = settings;
        }
    }
}
