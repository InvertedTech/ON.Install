using Grpc.Core;
using Grpc.Core.Logging;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger logger;

        public StatsClient(ServiceNameHelper nameHelper, ILogger<StatsClient> logger)
        {
            this.nameHelper = nameHelper;
            this.logger = logger;
        }

        public async Task RecordView(Guid contentId, ONUser user)
        {
            try
            {
                var client = new StatsViewInterface.StatsViewInterfaceClient(nameHelper.StatsServiceChannel);
                var res = await client.LogViewContentAsync(new LogViewContentRequest()
                {
                    ContentID = contentId.ToString(),
                }, GetMetadata(user));
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }
        }

        private Metadata GetMetadata(ONUser user)
        {
            var data = new Metadata();
            data.Add("Authorization", "Bearer " + user.JwtToken);

            return data;
        }
    }
}
