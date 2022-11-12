using Grpc.Core;
using ON.Authentication;
using ON.Fragments.Content.Stats;
using ON.Settings;
using System;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Service.Helpers
{
    public class StatsClient
    {
        private readonly ServiceNameHelper nameHelper;

        public StatsClient(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;
        }

        public async Task RecordView(Guid contentId, ONUser user)
        {
            var client = new StatsViewInterface.StatsViewInterfaceClient(nameHelper.StatsServiceChannel);
            var res = await client.LogViewContentAsync(new LogViewContentRequest()
            {
                ContentID = contentId.ToString(),
            }, GetMetadata(user));
        }

        private Metadata GetMetadata(ONUser user)
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + user.JwtToken);

            return data;
        }
    }
}
