using EventStore.Client;
using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.Extensions.Options;
using ON.Content.SimpleStats.Service.Models;
using ON.Fragments.Content.Stats;
using ON.Fragments.Settings;
using ON.Settings;
using System;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Helper
{
    public class EventDBHelper
    {
        private EventStoreClient client;

        public EventDBHelper(IOptions<AppSettings> settings)
        {
            var clientSettings = EventStoreClientSettings.Create(SettingsClient.ConnectionString);
            client = new EventStoreClient(clientSettings);
        }

        public async Task<StreamRevision?> Append(string streamName, StreamRevision? expectedRev, IMessage record)
        {
            if (expectedRev == null)
            {
                var res = await client.AppendToStreamAsync(
                                streamName,
                                StreamState.NoStream,
                                record.ToEventDataArray(),
                                (x) => x.ThrowOnAppendFailure = false
                        );

                if (res is SuccessResult)
                    return res.NextExpectedStreamRevision;
            }
            else
            {
                var res = await client.AppendToStreamAsync(
                                streamName,
                                expectedRev.Value.ToUInt64(),
                                record.ToEventDataArray(),
                                (x) => x.ThrowOnAppendFailure = false
                        );

                if (res is SuccessResult)
                    return res.NextExpectedStreamRevision;
            }


            return null;
        }

        public async Task<StreamRevision?> BlindAppend(string streamName, IMessage record)
        {
            var eventData = record.ToEventData();

            var res = await client.AppendToStreamAsync(
                            streamName,
                            StreamState.Any,
                            record.ToEventDataArray());

            if (res is SuccessResult)
                return res.NextExpectedStreamRevision;

            return null;
        }

        public async Task<bool> ConcurrentAppend(string streamName, Func<Task<(StreamRevision? rev, IMessage record)>> runner)
        {
            for (uint i = 0; i < 5; i++)
            {
                var todo = await runner();
                if (todo.record == null)
                    return true;

                var res = await Append(streamName, todo.rev, todo.record);
                if (res != null)
                    return true;
            }

            return false;
        }

        public async Task<ResolvedEvent?> GetLastEvent(string streamName)
        {
            var result = client.ReadStreamAsync(
                    Direction.Backwards,
                    streamName,
                    StreamPosition.End,
                    1);

            if (await result.ReadState != ReadState.Ok)
                return null;

            await foreach (var e in result)
            {
                return e;
            }

            return null;
        }

        public IMessage Parse(ResolvedEvent e)
        {
            var desc = GetDescriptor(e);
            if (desc == null)
                return null;

            var json = Encoding.ASCII.GetString(e.Event.Data.Span);
            return JsonParser.Default.Parse(json, desc);
        }

        public async Task SubscribeToAll(string streamName, Func<StreamSubscription, ResolvedEvent, CancellationToken, Task> eventAppeared, FromAll? fromAll = null)
        {
            FromAll f = fromAll ?? FromAll.Start;

            var prefixStreamFilter = new SubscriptionFilterOptions(StreamFilter.Prefix(streamName));
            await client.SubscribeToAllAsync(
                f,
                eventAppeared,
                filterOptions: prefixStreamFilter);
        }

        private MessageDescriptor? GetDescriptor(ResolvedEvent e)
        {
            var t = Assembly.GetAssembly(typeof(LikeContentEvent)).GetType(e.Event.EventType, false);
            if (t == null)
                return null;

            var pi = t.GetProperty("Descriptor", BindingFlags.Public | BindingFlags.Static);
            if (pi == null)
                return null;

            return pi.GetValue(null) as MessageDescriptor;
        }
    }
}
