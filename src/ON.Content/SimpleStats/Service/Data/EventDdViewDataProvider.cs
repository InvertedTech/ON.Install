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
    public class EventDdViewDataProvider : IViewDataProvider
    {
        private readonly EventDBHelper db;
        private const string streamBase = "stats-view-";

        public EventDdViewDataProvider(EventDBHelper db)
        {
            this.db = db;
        }

        public async Task LogView(Guid userId, Guid contentId)
        {
            var streamName = GetStreamName(userId);

            await db.BlindAppend(streamName, new ViewContentEvent()
                {
                    UserID = userId == Guid.Empty ? "" : userId.ToString(),
                    ContentID = contentId.ToString(),
                });
        }

        private string GetStreamName(Guid userId) => streamBase + userId.ToString().Replace("-", "");
    }
}
