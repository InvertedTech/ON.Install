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
    }
}
