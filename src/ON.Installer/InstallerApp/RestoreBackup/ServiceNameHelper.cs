using Grpc.Core;
using Microsoft.Extensions.Configuration;

namespace InstallerApp.BackupRestore
{
    public class ServiceNameHelper
    {
        public readonly Channel AuthenticationServiceChannel;
        public readonly Channel ContentServiceChannel;
        public readonly Channel FakePayServiceChannel;

        public Channel[] ChannelList => new Channel[] {
            AuthenticationServiceChannel,
            ContentServiceChannel,
            FakePayServiceChannel,
        };

        public ServiceNameHelper(string ip)
        {
            AuthenticationServiceChannel = new Channel(ip, 7001, ChannelCredentials.Insecure);
            ContentServiceChannel = new Channel(ip, 7002, ChannelCredentials.Insecure);
            FakePayServiceChannel = new Channel(ip, 7003, ChannelCredentials.Insecure);
        }
    }
}
