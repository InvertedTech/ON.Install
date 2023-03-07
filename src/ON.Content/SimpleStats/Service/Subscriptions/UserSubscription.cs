using EventStore.Client;
using ON.Content.SimpleStats.Service.Helper;
using System.Threading.Tasks;
using System.Threading;
using ON.Fragments.Content.Stats;
using Google.Protobuf;
using ON.Content.SimpleStats.Service.Data;
using ON.Fragments.Generic;
using System.Linq;
using Google.Type;
using Google.Protobuf.WellKnownTypes;

namespace ON.Content.SimpleStats.Service.Subscriptions
{
    public class UserSubscription
    {
        private readonly EventDBHelper eventDb;
        private readonly IStatsUserPublicDataProvider pubDb;
        private readonly IStatsUserPrivateDataProvider prvDb;

        public UserSubscription(EventDBHelper eventDb, IStatsUserPublicDataProvider pubDb, IStatsUserPrivateDataProvider prvDb)
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

                await Apply(d, e.Event.Position.CommitPosition, e.Event.Created);
            }
            catch { }
        }

        private Task Apply(IMessage e, ulong version, System.DateTime createdOn) => Task.CompletedTask; // this is just here so an exception doesn't get thrown if there is not apply for a new event

        private async Task Apply(LikeContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Likes++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.Likes.Contains(contentId.ToString()))
                    rPrv.Likes.Add(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(ProgressContentEvent e, ulong version, System.DateTime createdOn)
        {
            if (float.IsNaN(e.Progress))
                return;

            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                var rec = rPrv.ProgressRecords.FirstOrDefault(r => r.ContentID == e.ContentID);
                if (rec == null)
                {
                    rec = new()
                    {
                        ContentID = e.ContentID,
                        Progress = e.Progress,
                        UpdatedOnUTC = Timestamp.FromDateTime(createdOn),
                    };
                    rPrv.ProgressRecords.Add(rec);
                }
                else
                {
                    rec.Progress = e.Progress;
                    rec.UpdatedOnUTC = Timestamp.FromDateTime(createdOn);
                }

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(UnlikeContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Likes--;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                rPrv.Likes.Remove(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(SaveContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Saves++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.Saves.Contains(contentId.ToString()))
                    rPrv.Saves.Add(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(UnsaveContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Saves--;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                rPrv.Saves.Remove(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(ShareContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Shares++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.Shares.Contains(contentId.ToString()))
                    rPrv.Shares.Add(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }

        private async Task Apply(ViewContentEvent e, ulong version, System.DateTime createdOn)
        {
            var contentId = e.ContentID.ToGuid();
            var userId = e.UserID.ToGuid();
            var tPub = pubDb.GetById(userId);
            var tPrv = prvDb.GetById(userId);

            await Task.WhenAll(tPub, tPrv);

            var rPub = tPub.Result ?? new() { UserID = userId.ToString() };
            var rPrv = tPrv.Result ?? new() { UserID = userId.ToString() };

            if (rPub.Version < version)
            {
                rPub.Views++;
                rPub.Version = version;
                await pubDb.Save(rPub);
            }

            if (rPrv.Version < version)
            {
                if (!rPrv.Views.Contains(contentId.ToString()))
                    rPrv.Views.Add(contentId.ToString());

                rPrv.Version = version;
                await prvDb.Save(rPrv);
            }
        }
    }
}
