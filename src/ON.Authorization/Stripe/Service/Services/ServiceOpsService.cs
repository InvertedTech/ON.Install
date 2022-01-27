using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authorization.Stripe.Service.Models;
using ON.Fragments.Generic;
using System.Threading.Tasks;

namespace ON.Authorization.Stripe.Service
{
    public class ServiceOpsService : ServiceOpsInterface.ServiceOpsInterfaceBase
    {
        private readonly AppSettings appSettings;
        private readonly ILogger<ServiceOpsService> logger;

        public ServiceOpsService(ILogger<ServiceOpsService> logger, AppSettings appSettings)
        {
            this.appSettings = appSettings;
            this.logger = logger;
        }

        public override Task<ServiceStatusResponse> ServiceStatus(ServiceStatusRequest request, ServerCallContext context)
        {
            if (!appSettings.ContainsSecrets)
            {
                return Task.FromResult(new ServiceStatusResponse()
                {
                    Status = ServiceStatusResponse.Types.OnlineStatus.Faulted
                });
            }

            return Task.FromResult(new ServiceStatusResponse()
            {
                Status = ServiceStatusResponse.Types.OnlineStatus.Online
            });
        }
    }
}
