using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Fragments.Content;

namespace ON.Content.SimpleCMS.Service
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

            List<ContentRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
                list.Add(rec);

            res.Records.AddRange(list.OrderByDescending( r => r.Public.CreatedOnUTC));

            return res;
        }

        public override async Task<GetContentResponse> GetContent(GetContentRequest request, ServerCallContext context)
        {
            //var userToken = context.GetHttpContext().User as ONUser;
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
            var content = request.Content;

            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new SaveContentResponse();

            if (!(user.IsAdmin || user.IsPublisher || user.IsWriter))
                return new SaveContentResponse();

            await dataProvider.Save(content);

            return new SaveContentResponse()
            {
                Content = content
            };
        }
    }
}
