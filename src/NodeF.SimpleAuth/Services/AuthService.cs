using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.SimpleAuth
{
    public class AuthService : AuthenticationProvider.AuthenticationProviderBase
    {
        private readonly ILogger<AuthService> _logger;
        public AuthService(ILogger<AuthService> logger)
        {
            _logger = logger;
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
