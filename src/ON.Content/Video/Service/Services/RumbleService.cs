using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Collections;
using Grpc.Core;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using ON.Content.Video.Service.Data;
using RestSharp;
using ON.Content.Video.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        public override async Task<RumbleVideoResponse> RumbleVideoLinkById(RumbleVideoIdRequest request, ServerCallContext context)
        {
            var res = await httpRumble.MediaItemRequest(request);

            if (res.Content != null)
            {
                var json = JObject.Parse(res.Content);
                var video = json.SelectToken("video");
                var embed = video.SelectToken("iframe");
                RumbleVideo rumbleVideo = new RumbleVideo()
                {
                    Id = request.Fid.ToString(),
                    Language = "en",
                    Embed = embed.ToString(),
                    Title = json.SelectToken("title").ToString(),
                    ChannelId = json.SelectToken("channel").ToString(),
                    IsPrivate = ((bool)json.SelectToken("private"))
                };

                // TODO: Serialize rumbleVideo to protobuf

                return new RumbleVideoResponse()
                {
                    Success = true,
                    Msg = "Video Found",
                    Video = rumbleVideo
                };
            }

            return new RumbleVideoResponse()
            {
                Success = false,
                Error = "err"
            };
        }

        public async Task<RumbleVideoResponse> RumbleVideoLink(RumbleVideoIdRequest request)
        {
            await Task.Delay(100);
            return new RumbleVideoResponse();
        }


    }
}
