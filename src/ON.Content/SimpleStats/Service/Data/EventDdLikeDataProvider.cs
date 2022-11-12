using EventStore.Client;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.SimpleStats.Service.Helper;
using ON.Content.SimpleStats.Service.Models;
using ON.Fragments.Content;
using ON.Fragments.Content.Stats;
using ON.Fragments.Generic;
using ON.Fragments.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public class EventDdLikeDataProvider : ILikeDataProvider
    {
        private readonly EventDBHelper db;
        private const string streamBase = "stats-like-";

        public EventDdLikeDataProvider(EventDBHelper db)
        {
            this.db = db;
        }

        public async Task Like(Guid userId, Guid contentId)
        {
            var streamName = GetStreamName(userId, contentId);

            var res = await db.ConcurrentAppend(streamName, async () =>
            {
                var status = await GetCurrentStatus(streamName);

                if (status.isLiked)
                    return (null, null);

                return (status.lastRev, new LikeContentEvent()
                {
                    UserID = userId.ToString(),
                    ContentID = contentId.ToString(),
                });
            });
        }

        public async Task Unlike(Guid userId, Guid contentId)
        {
            var streamName = GetStreamName(userId, contentId);

            var res = await db.ConcurrentAppend(streamName, async () =>
            {
                var status = await GetCurrentStatus(streamName);

                if (!status.isLiked)
                    return (null, null);

                return (status.lastRev, new UnlikeContentEvent()
                {
                    UserID = userId.ToString(),
                    ContentID = contentId.ToString(),
                });
            });
        }

        private async Task<(bool isLiked, StreamRevision? lastRev)> GetCurrentStatus(string streamName)
        {
            var res = await db.GetLastEvent(streamName);
            if (res == null)
                return (false, null);

            var e = res.Value;
            switch (e.Event.EventType)
            {
                case string s when s.EndsWith(nameof(LikeContentEvent)):
                    return (true, e.Event.EventNumber.ToUInt64());
                default:
                    return (false, e.Event.EventNumber.ToUInt64());
            }
        }

        private string GetStreamName(Guid userId, Guid contentId) => streamBase + $"{userId.ToString().Replace("-", "")}-{contentId.ToString().Replace("-", "")}";
    }
}
