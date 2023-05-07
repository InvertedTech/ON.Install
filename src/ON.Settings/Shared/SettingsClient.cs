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

namespace ON.Settings
{
    public class SettingsClient
    {
        private EventStoreClient client;
        private string streamName = "simplesettings";

        public SettingsPublicData PublicData { get; private set; }
        public SettingsPrivateData PrivateData { get; private set; }
        public SettingsOwnerData OwnerData { get; private set; }

        public uint CurrentSettingsId => PublicData.VersionNum;

        public SettingsClient(IOptions<SettingsClientSettings> settings)
        {
            var dbSettings = EventStoreClientSettings.Create(settings.Value.EventDBConnStr);
            client = new EventStoreClient(dbSettings);
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
