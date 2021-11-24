using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service.Helper
{
    public class ServiceNameHelper
    {
        public readonly Channel PaymentServiceChannel;

        public ServiceNameHelper(IConfiguration configuration, ILogger<ServiceNameHelper> logger)
        {
            var uri = configuration.GetServiceUri("payservice");

            if (uri != null)
                PaymentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
