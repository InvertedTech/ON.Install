using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Collections;
using Grpc.Core;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using ON.Content.Video.Service.Models;

namespace ON.Content.Video.Service
{
    public class VideoService : VideoInterface.VideoInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly IFileSystemRumbleProvider rumbleProvider;

        public VideoService(ILogger<ServiceOpsService> logger, IFileSystemRumbleProvider rumbleProvider)
        {
            this.logger = logger;
            this.rumbleProvider = rumbleProvider;
        }

        public async Task<DataResponse> GetData(GetDataRequest request)
        {
            return new DataResponse();
        }


    }
}
