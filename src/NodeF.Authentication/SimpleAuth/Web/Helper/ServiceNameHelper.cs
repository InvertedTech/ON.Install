using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Web.Helper
{
    public class ServiceNameHelper
    {
        public readonly Channel UserServiceChannel;

        public ServiceNameHelper(IConfiguration configuration, ILogger<ServiceNameHelper> logger)
        {
            var uri = configuration.GetServiceUri("authservice");

            logger.LogWarning($"******Trying to connect to AuthService at:({uri.ToString()})******");

            if (uri != null)
                UserServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
