using Grpc.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.ParallelEconomy.Web.Helper
{
    public class ServiceNameHelper
    {
        public readonly Channel PaymentsServiceChannel;

        public ServiceNameHelper(IConfiguration configuration)
        {
            var uri = configuration.GetServiceUri("paralleleconomyservice");
            PaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
