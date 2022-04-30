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
        private readonly FileSystemRumbleDataProvider rumbleDataProvider;

        public RumbleService(ILogger<ServiceOpsService> logger, IOptions<AppSettings> settings, FileSystemRumbleDataProvider dataProvider)
        {
            this.logger = logger;
            appSettings = settings;
            httpRumble = new HttpRumbleProvider(logger, appSettings);
            rumbleDataProvider = dataProvider;
        }

        public override async Task<RumbleData> ConnectToRumbleChannel(RumbleChannelRequest request, ServerCallContext context)
        {
            RumbleData data = new RumbleData();
            var httpResponse = await httpRumble.MediaSearchRequest(request);
            var body = httpResponse.Content;

            if (body != null)
            {
                var deserializedResponse = JsonConvert.DeserializeObject<ResponseMapping>(body);
                Result[] results = deserializedResponse.results;
                foreach (Result result in results)
                {
                    var video = new RumbleVideo
                    {
                        Id = result.fid,
                        Embed = result.video.iframe,
                        Title = result.title,
                        IsPrivate = result.isprivate,
                        Channel = request.ChannelId
                    };

                    data.Videos.Add(video);
                }

                await rumbleDataProvider.SaveData(data);
                return data;
            }

            return data;
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
