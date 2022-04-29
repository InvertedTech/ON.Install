using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Collections;
using Grpc.Core;
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.Video.Service
{
    public class RumbleService : RumbleInterface.RumbleInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;

        public RumbleService(ILogger<ServiceOpsService> logger)
        {
            this.logger = logger;
        }

        public async Task<RumbleChannelResponse> RumbleChannelConnection(RumbleChannelRequest request)
        {
            await Task.Delay(100);
            return new RumbleChannelResponse();
        }

        public async Task<RumbleVideoResponse> RumbleVideoLinkById(RumbleVideoIdRequest request)
        {
            await Task.Delay(100);
            return new RumbleVideoResponse();
        }

        public async Task<RumbleVideoResponse> RumbleVideoLink(RumbleVideoIdRequest request)
        {
            await Task.Delay(100);
            return new RumbleVideoResponse();
        }


    }
}
