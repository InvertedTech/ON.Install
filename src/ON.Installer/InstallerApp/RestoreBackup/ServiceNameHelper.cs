using Grpc.Core;
using Microsoft.Extensions.Configuration;

namespace InstallerApp.BackupRestore
{
    public class ServiceNameHelper
    {
        public readonly Channel AuthenticationServiceChannel;
        public readonly Channel ContentServiceChannel;
        public readonly Channel PaymentsServiceChannel;

        public Channel[] ChannelList => new Channel[] {
            AuthenticationServiceChannel,
            ContentServiceChannel,
            //PaymentsServiceChannel,
        };

        public ServiceNameHelper()
        {
            AuthenticationServiceChannel = new Channel("localhost", 8080, ChannelCredentials.Insecure);
            ContentServiceChannel = new Channel("localhost", 8080, ChannelCredentials.Insecure);
            PaymentsServiceChannel = new Channel("localhost", 8080, ChannelCredentials.Insecure);
        }
    }
}
