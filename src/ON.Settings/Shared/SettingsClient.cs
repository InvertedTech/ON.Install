using ON.Fragments.Settings;
using System.Threading.Tasks;
using System.Linq;
using ON.Authentication;
using Grpc.Core;
using EventStore.Client;
using System;
using System.Threading;
using System.Text;
using PubSub;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ON.Crypto;

namespace ON.Settings
{
    public class SettingsClient
    {
        public const string EVENT_DB_SERVER_NAME = "EVENT_DB_SERVER_NAME";

        private EventStoreClient client;
        private string streamName = "simplesettings";
        private ServiceNameHelper nameHelper;

        public SettingsPublicData PublicData { get; private set; }
        public SettingsPrivateData PrivateData { get; private set; }
        public SettingsOwnerData OwnerData { get; private set; }

        public uint CurrentSettingsId => PublicData.VersionNum;

        public SettingsClient(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;

            var dbSettings = EventStoreClientSettings.Create(ConnectionString);
            client = new EventStoreClient(dbSettings);
            SubscribeToEvents().Wait();
        }

        public static string ConnectionString { get
            {
                var serverName = GetFromEnvVar(EVENT_DB_SERVER_NAME);
                if (string.IsNullOrEmpty(serverName))
                    serverName = "eventdb";

                string connStr = $"esdb://{serverName}:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000";
                return connStr;
            }
        }

        private static string GetFromEnvVar(string envName)
        {
            return Environment.GetEnvironmentVariable(envName, EnvironmentVariableTarget.Process);
        }

        private async Task SubscribeToEvents()
        {
            try
            {
                await LoadLatest();
                await client.SubscribeToStreamAsync(streamName, FromStream.End, ProcessEvent);
            }
            catch
            {
                try
                {
                    await LoadLatestDirect();
                    await LoadLatest();
                    await client.SubscribeToStreamAsync(streamName, FromStream.End, ProcessEvent);
                }
                catch
                {
                }
            }
        }

        public async Task LoadLatest()
        {
            var result = client.ReadStreamAsync(
                Direction.Backwards,
                streamName,
                StreamPosition.End);

            var e = await result.FirstOrDefaultAsync();
            var json = Encoding.ASCII.GetString(e.Event.Data.Span);
            var record = Google.Protobuf.JsonParser.Default.Parse<SettingsRecord>(json);

            Load(record);
        }

        public async Task LoadLatestDirect()
        {
            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetPublicDataAsync(new());

            PublicData = res.Public;
        }

        private async Task ProcessEvent(StreamSubscription sub, ResolvedEvent e, CancellationToken token)
        {
            var json = Encoding.ASCII.GetString(e.Event.Data.Span);
            var record = Google.Protobuf.JsonParser.Default.Parse<SettingsRecord>(json);

            Load(record);

            await Hub.Default.PublishAsync(record);
        }

        private void Load(SettingsRecord record)
        {
            PublicData = record.Public;
            PrivateData = record.Private;
            OwnerData = record.Owner;
        }
    }
}
