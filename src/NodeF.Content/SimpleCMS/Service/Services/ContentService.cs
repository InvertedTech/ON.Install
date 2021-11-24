using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using NodeF.Authentication;
using NodeF.Content.SimpleCMS.Service.Data;
using NodeF.Fragments.Content;

namespace NodeF.Content.SimpleCMS.Service
{
    public class ContentService : ContentInterface.ContentInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly IContentDataProvider dataProvider;

        public ContentService(ILogger<ServiceOpsService> logger, IContentDataProvider dataProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
        }

        public override async Task<GetAllContentResponse> GetAllContent(GetAllContentRequest request, ServerCallContext context)
        {
            var res = new GetAllContentResponse();

            res.Records.AddRange(await dataProvider.GetAll());

            return res;
        }

        public override async Task<GetContentResponse> GetContent(GetContentRequest request, ServerCallContext context)
        {
            //var userToken = context.GetHttpContext().User as NodeUser;
            Guid contentId = new Guid(request.ContentID.ToByteArray());

            if (contentId == Guid.Empty)
                return new GetContentResponse();

            return new GetContentResponse
            {
                Content = await dataProvider.GetById(contentId)
            };
        }

        public override async Task<SaveContentResponse> SaveContent(SaveContentRequest request, ServerCallContext context)
        {
            //var userToken = context.GetHttpContext().User as NodeUser;
            var content = request.Content;

            await dataProvider.Save(content);

            return new SaveContentResponse()
            {
                Content = content
            };
        }
    }
}
