using Grpc.Core;
using Microsoft.Extensions.Configuration;

namespace NodeF.Backup.SimpleBackup.Service.Services
{
    public class ServiceNameHelper
    {
        public readonly Channel AuthenticationServiceChannel;
        public readonly Channel SubscriptionServiceChannel;
        public readonly Channel ContentServiceChannel;

        public Channel[] ChannelList => new Channel[] {
            AuthenticationServiceChannel,
            SubscriptionServiceChannel,
            ContentServiceChannel
        };

        public ServiceNameHelper(IConfiguration configuration)
        {
            var uri = configuration.GetServiceUri("authservice");
            if (uri != null)
                AuthenticationServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("payservice");
            if (uri != null)
                SubscriptionServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("cmsservice");
            if (uri != null)
                ContentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);
        }
    }
}
