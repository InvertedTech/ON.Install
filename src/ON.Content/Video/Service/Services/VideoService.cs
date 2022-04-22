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
                LinkGUID = request.PlatformVideoID,
                HostPlatform = request.HostPlatform,
                PlatformVideoID = request.PlatformVideoID,
                CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                Embed = "insert code"
            };

            logger.LogWarning($"***LinkVideo: {link}***");
            await dataProvider.Save(link);

            return new LinkVideoResponse()
            {
                Success = true,
                Linkedvideo = link,
                CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
            };
        }
    }
}
