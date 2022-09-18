using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Helper
{
    public class ServiceNameHelper
    {
        public readonly GrpcChannel ContentServiceChannel;
        public readonly Channel SettingsServiceChannel;
        public readonly Channel UserServiceChannel;
        public readonly Channel FakePaymentsServiceChannel;
        public readonly Channel PaypalPaymentsServiceChannel;
        public readonly Channel StripePaymentsServiceChannel;
        public readonly Channel PEPaymentsServiceChannel;

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

            uri = configuration.GetServiceUri("fakepayservice", "grpc");
            if (uri != null)
                FakePaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("paypalservice", "grpc");
            if (uri != null)
                PaypalPaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("stripeservice", "grpc");
            if (uri != null)
                StripePaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

            uri = configuration.GetServiceUri("peservice", "grpc");
            if (uri != null)
                PEPaymentsServiceChannel = new Channel(uri.Host, uri.Port, ChannelCredentials.Insecure);

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
