using Grpc.Core;
using Grpc.Core.Logging;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ON.Fragments.Authentication;
using System;
using System.Threading.Tasks;

namespace ON.Settings
{
    public class ServiceNameHelper
    {
        private readonly ILogger<ServiceNameHelper> logger;

        public readonly GrpcChannel ContentServiceChannel;
        public readonly Channel ChatServiceChannel;
        public readonly Channel CommentServiceChannel;
        public readonly Channel NotificationServiceChannel;
        public readonly Channel PaymentServiceChannel;
        public readonly Channel SettingsServiceChannel;
        public readonly Channel StatsServiceChannel;
        public readonly Channel UserServiceChannel;

        public readonly string ServiceToken;

        public ServiceNameHelper(IConfiguration configuration, ILogger<ServiceNameHelper> logger)
        {
            this.logger = logger;

            var options = new GrpcChannelOptions
            {
                MaxReceiveMessageSize = null,
                MaxSendMessageSize = null,
            };

            var uri = configuration.GetServiceUri("authservice", "grpc");
            if (uri != null)
                UserServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("chatservice", "grpc");
            if (uri != null)
                ChatServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("commentservice", "grpc");
            if (uri != null)
                CommentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("settingsservice", "grpc");
            if (uri != null)
                SettingsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("cmsservice", "grpc");
            if (uri != null)
                ContentServiceChannel = GrpcChannel.ForAddress(uri, options);

            uri = configuration.GetServiceUri("notificationservice", "grpc");
            if (uri != null)
                NotificationServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("paymentservice", "grpc");
            if (uri != null)
                PaymentServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("statsservice", "grpc");
            if (uri != null)
                StatsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            ServiceToken = GetServiceToken();
        }

        private string GetServiceToken()
        {
            try
            {
                var client = new ServiceInterface.ServiceInterfaceClient(UserServiceChannel);
                var reply = client.AuthenticateService(new(), null, DateTime.UtcNow.AddSeconds(5));

                return reply?.BearerToken;
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error in ON.Settings.ServiceNameHelper.GetServiceToken");
                return null;
            }
        }
    }
}
