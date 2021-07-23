using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Fragments.Generic;

namespace NodeF.Content.SimpleCMS.Service
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
