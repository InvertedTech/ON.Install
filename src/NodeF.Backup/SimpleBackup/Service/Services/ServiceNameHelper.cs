using Grpc.Core;
using Microsoft.Extensions.Configuration;

namespace NodeF.Backup.SimpleBackup.Service.Services
{
    public class ServiceNameHelper
    {
        public readonly Channel AuthenticationServiceChannel;

        public ServiceNameHelper(IConfiguration configuration)
        {
            var uri = configuration.GetServiceUri("authservice");
            if (uri != null)
                AuthenticationServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
