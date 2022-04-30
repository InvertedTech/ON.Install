using Grpc.Core;
using ON.Fragments.Content;
using ON.Content.Video.Service.Data;
using ON.Content.Video.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// Todo: Save channels
namespace ON.Content.Video.Service
{
    public class RumbleService : RumbleInterface.RumbleInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private HttpRumbleProvider httpRumble;
        private readonly IOptions<AppSettings> appSettings;

        public RumbleService(ILogger<ServiceOpsService> logger, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            appSettings = settings;
            httpRumble = new HttpRumbleProvider(logger, appSettings);
        }

        public override async Task<RumbleChannelResponse> RumbleChannelConnection(RumbleChannelRequest request, ServerCallContext context)
        {
            RumbleChannel channel = new RumbleChannel
            {
                Id = request.ChannelId,
            };
            var res = await httpRumble.MediaSearchRequest(request);
            var json = res.Content;

            if (json != null)
            {
                var deserial = JsonConvert.DeserializeObject<ResponseMapping>(json);
                Result[] results = deserial.results;

                foreach (var result in results)
                {

                    var video = new RumbleVideo
                    {
                        Id = result.fid,
                        Embed = result.video.iframe,
                        Title = result.title,
                        IsPrivate = result.isprivate,
                    };
                    channel.Videos.Add(video);
                }
                
                return new RumbleChannelResponse
                {
                    Success = true,
                    Msg = "Channel Found",
                    Channel = channel
                };
                
            }



            return new RumbleChannelResponse
            {
                Success = false,
            };
        }


    }

    internal class ResponseMapping
    {
        public Result[] results { get; set; }
    }

    internal class Result
    {
        public string fid { get; set; }
        public string title { get; set; }
        public dynamic video { get; set; }
        public bool isprivate { get; set; }

    }
}
