using Grpc.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Helpers
{
    public class ServiceNameHelper
    {
        public readonly Channel ChatServiceChannel;
        public readonly Channel PaymentServiceChannel;

        public ServiceNameHelper(IConfiguration configuration, ILogger<ServiceNameHelper> logger)
        {
            Uri uri;

            uri = configuration.GetServiceUri("chatservice", "grpc");
            if (uri != null)
                ChatServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("paymentservice", "grpc");
            if (uri != null)
                PaymentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
