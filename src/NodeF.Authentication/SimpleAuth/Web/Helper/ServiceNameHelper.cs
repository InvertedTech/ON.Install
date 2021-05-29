using Grpc.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Web.Helper
{
    public class ServiceNameHelper
    {
        public readonly Channel UserServiceChannel;

        public ServiceNameHelper(IConfiguration configuration)
        {
            var uri = configuration.GetServiceUri("service");
            UserServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
