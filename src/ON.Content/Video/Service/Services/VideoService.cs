using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ON.Content.Video.Service.Data;
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.Video.Service
{
    public class VideoService : VideoInterface.VideoInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly IVideoLinkDataProvider dataProvider;

        public VideoService(ILogger<ServiceOpsService> logger, IVideoLinkDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        public override async Task<LinkVideoResponse> LinkVideo(LinkVideoRequest request, ServerCallContext context)
        {
            VideoLink link = new VideoLink
            {
                LinkGUID = Guid.NewGuid().ToString(),
                HostPlatform = request.HostPlatform,
                PlatformVideoID = request.PlatformVideoID,
                CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                Embed = "insert code",
                VideoUrl = "insert URL"
            };

            var ledger = await dataProvider.GetAll();

            if (ledger == null)
            {
                ledger = new VideoLinkLedger();
            }

            ledger.VideoLinks.Add(link);

            logger.LogWarning($"***LinkVideo: {ledger}***");
            await dataProvider.SaveAll(ledger);

            return new LinkVideoResponse()
            {
                Success = true,
                Linkedvideo = link
            };
        }

        public override async Task<GetAllLinkResponse> GetAllVideoLinks(GetAllLinkRequest request, ServerCallContext context)
        {
            VideoLinkLedger ledger = await dataProvider.GetAll();
            List<VideoLink> videoLinks = new List<VideoLink>();
            logger.LogWarning($"***{ledger}***");
            foreach (var videoLink in ledger.VideoLinks)
            {
                videoLinks.Add(new VideoLink()
                {
                    LinkGUID = videoLink.LinkGUID,
                    HostPlatform = videoLink.HostPlatform,
                    PlatformVideoID = videoLink.PlatformVideoID,
                    VideoUrl = videoLink.VideoUrl,
                    CreatedOnUTC = videoLink.CreatedOnUTC,
                    ModifiedOnUTC = videoLink.ModifiedOnUTC,
                    Embed = videoLink.Embed,
                });
            }
            var res = new GetAllLinkResponse();
            res.Links.AddRange(videoLinks.OrderByDescending(r => r.CreatedOnUTC));
            return res;
        }
    }
}
