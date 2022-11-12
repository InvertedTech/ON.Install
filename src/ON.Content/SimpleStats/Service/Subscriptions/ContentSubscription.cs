using EventStore.Client;
using ON.Content.SimpleStats.Service.Helper;
using System.Threading.Tasks;
using System.Threading;
using ON.Fragments.Content.Stats;
using Google.Protobuf;
using ON.Content.SimpleStats.Service.Data;
using ON.Fragments.Generic;

namespace ON.Content.SimpleStats.Service.Subscriptions
{
    public class ContentSubscription
    {
        private readonly EventDBHelper eventDb;
        private readonly IStatsContentPublicDataProvider pubDb;
        private readonly IStatsContentPrivateDataProvider prvDb;

        public ContentSubscription(EventDBHelper eventDb, IStatsContentPublicDataProvider pubDb, IStatsContentPrivateDataProvider prvDb)
        {
            this.eventDb = eventDb;
            eventDb.SubscribeToAll("stats-", OnNewEvent).Wait();

            this.pubDb = pubDb;
            this.prvDb = prvDb;
        }

        private async Task OnNewEvent(StreamSubscription stream, ResolvedEvent e, CancellationToken token)
        {
            try
            {
                var msg = eventDb.Parse(e);
                if (msg == null)
                    return;

                dynamic d = msg;

                await Apply(d, e.Event.Position.CommitPosition);
            }
            catch { }
        }

        private Task Apply(IMessage e, ulong version) => Task.CompletedTask; // this is just here so an exception doesn't get thrown if there is not apply for a new event

        private async Task Apply(LikeContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Likes++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.LikedBy.Contains(userId.ToString()))
                    rPrv.LikedBy.Add(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(UnlikeContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Likes--;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                rPrv.LikedBy.Remove(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(SaveContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Saves++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.SavedBy.Contains(userId.ToString()))
                    rPrv.SavedBy.Add(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(UnsaveContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Saves--;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                rPrv.SavedBy.Remove(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(ShareContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Shares++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.SharedBy.Contains(userId.ToString()))
                    rPrv.SharedBy.Add(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(ViewContentEvent e, ulong version)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(contentId);
            var tPrv = prvDb.GetById(contentId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { ContentID = contentId.ToString() };
            var rPrv = tPrv.Result ?? new() { ContentID = contentId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Views++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.ViewedBy.Contains(userId.ToString()))
                    rPrv.ViewedBy.Add(userId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }
    }
}
