using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Fragments.Generic;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Services
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
