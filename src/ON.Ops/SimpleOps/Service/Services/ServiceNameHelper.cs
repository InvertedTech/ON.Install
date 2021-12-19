using Grpc.Core;
using Microsoft.Extensions.Configuration;

namespace ON.Backup.SimpleBackup.Service.Services
{
    public class ServiceNameHelper
    {
        public readonly Channel AuthenticationServiceChannel;
        public readonly Channel PaymentsServiceChannel;
        public readonly Channel ContentServiceChannel;

        public Channel[] ChannelList => new Channel[] {
            AuthenticationServiceChannel,
            //ContentServiceChannel
            //PaymentsServiceChannel,
        };

        public ServiceNameHelper(IConfiguration configuration)
        {
            var uri = configuration.GetServiceUri("authservice");
            if (uri != null)
                AuthenticationServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("payservice");
            if (uri != null)
                PaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("cmsservice");
            if (uri != null)
                ContentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
