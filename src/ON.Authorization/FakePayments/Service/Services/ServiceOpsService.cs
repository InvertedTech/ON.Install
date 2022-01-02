using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Fragments.Generic;
using System.Threading.Tasks;

namespace ON.Authorization.FakePayments.Service
{
    public class ServiceOpsService : ServiceOpsInterface.ServiceOpsInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        public ServiceOpsService(ILogger<ServiceOpsService> logger)
        {
            this.logger = logger;
        }

        public override Task<ServiceStatusResponse> ServiceStatus(ServiceStatusRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ServiceStatusResponse()
            {
                Status = ServiceStatusResponse.Types.OnlineStatus.Online
            });
        }
    }
}
