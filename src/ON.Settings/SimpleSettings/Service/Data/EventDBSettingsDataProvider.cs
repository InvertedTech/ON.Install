using EventStore.Client;
using Grpc.Net.Client.Balancer;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Fragments.Settings;
using ON.Settings.SimpleSettings.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace ON.Settings.SimpleSettings.Service.Data
{
    public class EventDBSettingsDataProvider : ISettingsDataProvider
    {
        private readonly ILogger logger;

        private EventStoreClient client;
        private string streamName = "simplesettings";

        public EventDBSettingsDataProvider(ILogger<EventDBSettingsDataProvider> logger)
        {
            this.logger = logger;

            var clientSettings = EventStoreClientSettings.Create(SettingsClient.ConnectionString);
            client = new EventStoreClient(clientSettings);
        }

        public async Task Clear()
        {
            await client.DeleteAsync(streamName, StreamState.Any);
        }

        public async Task<SettingsRecord> Get()
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

                return record;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Get()");
            }

            return null;
        }

        public async IAsyncEnumerable<SettingsRecord> GetAll()
        {
            var result = client.ReadStreamAsync(
                Direction.Backwards,
                streamName,
                StreamPosition.End);

            await foreach (var e in result)
            {
                var json = Encoding.ASCII.GetString(e.Event.Data.Span);
                var record = Google.Protobuf.JsonParser.Default.Parse<SettingsRecord>(json);
                yield return record;
            }
        }

        public async Task Save(SettingsRecord record)
        {
            try
            {
                var json = Google.Protobuf.JsonFormatter.Default.Format(record);

                var eventData = new EventData(
                    Uuid.NewUuid(),
                    nameof(SettingsRecord),
                    Encoding.ASCII.GetBytes(json)
                );

                await client.AppendToStreamAsync(
                                streamName,
                                StreamState.Any,
                                new[] { eventData }
                        );
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in Save()");
            }
        }
    }
}
