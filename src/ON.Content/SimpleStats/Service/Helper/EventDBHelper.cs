using EventStore.Client;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.SimpleStats.Service.Models;
using ON.Fragments.Content.Stats;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Helper
{
    public class EventDBHelper
    {
        private readonly string connStr;
        private EventStoreClient client;

        public EventDBHelper(IOptions<AppSettings> settings)
        {
            connStr = settings.Value.EventDBConnStr;
            var clientSettings = EventStoreClientSettings.Create(connStr);
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
    }
}
