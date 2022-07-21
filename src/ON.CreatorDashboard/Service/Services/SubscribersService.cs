using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Fragments.CreatorDashboard.Subscribers;
using ON.CreatorDashboard.Service.Models;
using ON.CreatorDashboard.Service.Interfaces;

namespace ON.CreatorDashboard.Service
{
    public class SubscribersService : SubscriberInterface.SubscriberInterfaceBase
    {
        private readonly ILogger<SubscribersService> logger;
        private readonly IOptions<AppSettings> settings;
        private IMuteListProvider muteListProvider;
        private readonly IBanListProvider banListProvider;

        public SubscribersService(ILogger<SubscribersService> logger, IOptions<AppSettings> settings, IMuteListProvider muteListProvider, IBanListProvider banListProvider)
        {
            this.logger = logger;
            this.settings = settings;
            this.muteListProvider = muteListProvider;
            this.banListProvider = banListProvider;
        }

        private Mute CreateMute(MuteRequest req) 
        {
            Mute mute = new Mute()
            {
                UserId = req.UserId,
                Length = req.Length,
                Message = req.Message,
                MutedBy = req.MutedBy,
                Reason = req.Reason,
                DateMuted = new Google.Protobuf.WellKnownTypes.Timestamp()
            };

            return mute;
        }

        private Mute? IsMuted(MuteList list, string userId)
        {
            foreach (Mute mute in list.Mutes)
            {
                if (mute.UserId == userId) { return mute; }
            }

            return null;
        }

        private Ban? IsBanned(BanList list, string userId)
        {
            foreach (Ban ban in list.Bans)
            {
                if (ban.UserId == userId) { return ban; }
            }

            return null;
        }

        private Ban CreateBan(BanRequest req)
        {
            Ban ban = new Ban()
            {
                UserId = req.UserId,
                Length = req.Length,
                Message = req.Message,
                BannedBy = req.BannedBy,
                Reason = req.Reason,
                DateBanned = new Google.Protobuf.WellKnownTypes.Timestamp()
            };

            return ban;
        }

        public override async Task<GetMuteListResponse> GetMuteList(GetMuteListRequest req, ServerCallContext context)
        {
            var muteList = await this.muteListProvider.GetAll();
            // logger.LogWarning($"mutes: {muteList}");

            return new GetMuteListResponse()
            {
                MuteList = muteList,
            };
        }

        public override async Task<MuteResponse> MuteSubscriber(MuteRequest req
            , ServerCallContext context)
        {
            var muteList = await this.muteListProvider.GetAll();

            // Check if user is already muted
            var mutedUser = IsMuted(muteList, req.UserId);
            if (mutedUser != null)
            {
                return new MuteResponse()
                {
                    Message = "User already muted",
                    Mute = mutedUser
                };
            }

            
            // If not already muted, save mute list
            Mute mute = this.CreateMute(req);
            muteList.Mutes.Add(mute);
            await this.muteListProvider.SaveAll(muteList);

            return new MuteResponse()
            {
                Message = "Muted user",
                Mute = mute
            };
        }

        public override Task<UnmuteResponse> UnmuteSubscriber(UnmuteRequest req, ServerCallContext context)
        {
            return null;
        }

        public override async Task<GetBanListResponse> GetBanList(GetBanListRequest req, ServerCallContext context)
        {
            var banList = await this.banListProvider.GetAll();
            // logger.LogWarning($"mutes: {banList}");

            return new GetBanListResponse()
            {
                BanList = banList,
            };
        }

        public override async Task<BanResponse> BanSubscriber(BanRequest req, ServerCallContext context)
        {
            var banList = await this.banListProvider.GetAll();

            // Check if user is already banned
            var bannedUser = IsBanned(banList, req.UserId);
            if (bannedUser != null)
            {
                return new BanResponse()
                {
                    Message = "User already banned",
                    Ban = bannedUser,
                };
            }

            // If not already banned, save ban list
            Ban ban = this.CreateBan(req);
            banList.Bans.Add(ban);
            await this.banListProvider.SaveAll(banList);

            return new BanResponse()
            {
                Message = "Banned user",
                Ban = ban
            };
        }

        public override Task<UnbanResponse> UnbanSubscriber(UnbanRequest req, ServerCallContext context)
        {
            return null;
        }
    }
}
