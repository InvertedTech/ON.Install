using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Settings
{
    public class ServiceNameHelper
    {
        public readonly GrpcChannel ContentServiceChannel;
        public readonly Channel SettingsServiceChannel;
        public readonly Channel UserServiceChannel;
        public readonly Channel NotificationServiceChannel;
        public readonly Channel PaymentServiceChannel;
        public readonly Channel StatsServiceChannel;

        public readonly string ServiceToken;

        public ServiceNameHelper(IConfiguration configuration)
        {
            var options = new GrpcChannelOptions
            {
                MaxReceiveMessageSize = null,
                MaxSendMessageSize = null,
            };

            var uri = configuration.GetServiceUri("authservice", "grpc");
            if (uri != null)
                UserServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

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

            ServiceToken = GetServiceToken().Result;
        }

        private async Task<string> GetServiceToken()
        {
            var client = new ServiceInterface.ServiceInterfaceClient(UserServiceChannel);
            var reply = await client.AuthenticateServiceAsync(new());

            return reply.BearerToken;
        }
    }
}
