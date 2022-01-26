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
        public readonly Channel FakePaymentServiceChannel;
        public readonly Channel PaypalServiceChannel;

        public ServiceNameHelper(IConfiguration configuration, ILogger<ServiceNameHelper> logger)
        {
            var uri = configuration.GetServiceUri("fakepayservice");
            if (uri != null)
                FakePaymentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("paypalservice");
            if (uri != null)
                PaypalServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
