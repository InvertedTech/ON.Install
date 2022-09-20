using ON.Fragments.Settings;
using System.Threading.Tasks;
using System.Linq;
using ON.Authentication;
using Grpc.Core;
using EventStore.Client;
using System;
using System.Threading;
using System.Text;

namespace ON.Settings
{
    public class SettingsClient
    {
        private string connStr = "esdb://127.0.0.1:2113?tls=false&keepAliveTimeout=10000&keepAliveInterval=10000";
        private EventStoreClient client;
        private string streamName = "simplesettings";

        public SettingsPublicData PublicData { get; private set; }
        public SettingsPrivateData PrivateData { get; private set; }
        public SettingsOwnerData OwnerData { get; private set; }

        public SettingsClient()
        {
            var settings = EventStoreClientSettings.Create(connStr);
            client = new EventStoreClient(settings);
            SubscribeToEvents().Wait();
        }

        private async Task SubscribeToEvents()
        {
            await LoadLatest();
            await client.SubscribeToStreamAsync(streamName, FromStream.End, ProcessEvent);
        }

        public async Task LoadLatest()
        {
            try
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
            catch { }
        }

        private Task ProcessEvent(StreamSubscription sub, ResolvedEvent e, CancellationToken token)
        {
            var json = Encoding.ASCII.GetString(e.Event.Data.Span);
            var record = Google.Protobuf.JsonParser.Default.Parse<SettingsRecord>(json);

            Load(record);

            return Task.CompletedTask;
        }

        private void Load(SettingsRecord record)
        {
            PublicData = record.Public;
            PrivateData = record.Private;
            OwnerData = record.Owner;
        }
    }
}
