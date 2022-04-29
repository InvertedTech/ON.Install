using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Collections;
using Grpc.Core;
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.Video.Service
{
    public class VideoService : VideoInterface.VideoInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;

        public VideoService(ILogger<ServiceOpsService> logger)
        {
            this.logger = logger;
        }

        public async Task<DataResponse> GetData(GetDataRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse> UpdateData(UpdateDataRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResponse> RemoveData(RemoveDataRequest request)
        {
            throw new NotImplementedException();
        }


    }
}
