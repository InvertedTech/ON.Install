using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ON.SimpleWeb.Models.CMS;
using ON.Settings;
using ON.SimpleWeb.Models.Comment;
using ON.Fragments.Comment;
using ON.Fragments.Content.Stats;

namespace ON.SimpleWeb.Services
{
    public class StatsService
    {
        private readonly ServiceNameHelper nameHelper;
        public readonly ONUser User;

        public StatsService(ServiceNameHelper nameHelper, ONUserHelper userHelper)
        {
            User = userHelper.MyUser;

            this.nameHelper = nameHelper;
        }

        public async Task<GetContentStatsResponse> GetContentStats(Guid contentId)
        {
            if (!User.IsLoggedIn)
                return null;

            var req = new GetContentStatsRequest()
            {
                ContentID = contentId.ToString(),
            };

            var client = new StatsQueryInterface.StatsQueryInterfaceClient(nameHelper.StatsServiceChannel);
            var res = await client.GetContentStatsAsync(req, GetMetadata());

            return res;
        }

        public async Task<IEnumerable<ContentListRecord>> GetSaves(ContentService contentService)
        {
            if (!User.IsLoggedIn)
                return null;

            var client = new StatsQueryInterface.StatsQueryInterfaceClient(nameHelper.StatsServiceChannel);
            var res = await client.GetOwnUserSavesAsync(new(), GetMetadata());

            if ((res?.SavedContentIDs?.Count() ?? 0) == 0)
                return Enumerable.Empty<ContentListRecord>();

            var res2 = await contentService.GetAllByIds(res.SavedContentIDs);

            return res2;
        }

        public async Task<SaveContentResponse> Save(ContentPublicRecord rec)
        {
            if (!User.IsLoggedIn)
                return null;

            var req = new SaveContentRequest
            {
                ContentID = rec.ContentID,
            };

            var client = new StatsSaveInterface.StatsSaveInterfaceClient(nameHelper.StatsServiceChannel);
            var res = await client.SaveContentAsync(req, GetMetadata());

            return res;
        }

        public async Task<SaveContentResponse> Unsave(ContentPublicRecord rec)
        {
            if (!User.IsLoggedIn)
                return null;

            var req = new SaveContentRequest
            {
                ContentID = rec.ContentID,
            };

            var client = new StatsSaveInterface.StatsSaveInterfaceClient(nameHelper.StatsServiceChannel);
            var res = await client.UnsaveContentAsync(req, GetMetadata());

            return res;
        }

        private Metadata GetMetadata()
        {
            var data = new Metadata();
            if (User != null && !string.IsNullOrWhiteSpace(User.JwtToken))
                data.Add("Authorization", "Bearer " + User.JwtToken);

            return data;
        }
    }
}
