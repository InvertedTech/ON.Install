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
using ON.Fragments.Generic;

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

        public override async Task<CreateContentResponse> CreateContent(CreateContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new CreateContentResponse();

            if (!(user.IsAdmin || user.IsPublisher || user.IsWriter))
                return new CreateContentResponse();

            var content = new ContentRecord
            {
                Public = new ContentRecord.Types.PublicData
                {
                    ContentID = Guid.NewGuid().ToString(),
                    Title = request.Title,
                    Subtitle = request.Subtitle,
                    Author = request.Author,
                    Body = request.Body ?? "",
                    CreatedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow),
                    SubscriptionLevel = request.SubscriptionLevel
                },
                Private = new ContentRecord.Types.PrivateData
                {
                    CreatedBy = user.Id.ToString()
                }
            };

            await dataProvider.Save(content);

            return new CreateContentResponse()
            {
                Content = content.Public
            };
        }

        public override async Task<GetAllContentResponse> GetAllContent(GetAllContentRequest request, ServerCallContext context)
        {
            bool hideUnpublished = false;
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsWriterOrHigher)
                hideUnpublished = true;

            var res = new GetAllContentResponse();

            List<ContentListRecord> list = new();
            await foreach (var rec in dataProvider.GetAll())
            {
                if (hideUnpublished && rec.Public.PublishedOnUTC == null)
                    continue;

                list.Add(new ContentListRecord()
                {
                    ContentID = rec.Public.ContentID,
                    CreatedOnUTC = rec.Public.CreatedOnUTC,
                    PublishedOnUTC = rec.Public.PublishedOnUTC,
                    Title = rec.Public.Title,
                    Subtitle = rec.Public.Subtitle,
                    SubscriptionLevel = rec.Public.SubscriptionLevel,
                });
            }

            res.Records.AddRange(list.OrderByDescending(r => r.CreatedOnUTC));

            return res;
        }

        public override async Task<GetContentResponse> GetContent(GetContentRequest request, ServerCallContext context)
        {
            bool hideUnpublished = false;
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null || !userToken.IsWriterOrHigher)
                hideUnpublished = true;

            Guid contentId = request.ContentID.ToGuid();

            if (contentId == Guid.Empty)
                return new GetContentResponse();

            var rec = await dataProvider.GetById(contentId);

            if (hideUnpublished)
            {
                if (rec.Public.PublishedOnUTC == null)
                    return new GetContentResponse();

                if ((userToken?.SubscriptionLevel ?? 0) < rec.Public.SubscriptionLevel)
                    rec.Public.Body = "";
            }

            return new GetContentResponse
            {
                Content = rec.Public
            };
        }

        public override async Task<ModifyContentResponse> ModifyContent(ModifyContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new ModifyContentResponse();

            if (!(user.IsAdmin || user.IsPublisher || user.IsWriter))
                return new ModifyContentResponse();

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new ModifyContentResponse();

            record.Public.Title = request.Title;
            record.Public.Subtitle = request.Subtitle;
            record.Public.Author = request.Author;
            record.Public.Body = request.Body;
            record.Public.SubscriptionLevel = request.SubscriptionLevel;
            record.Public.ModifiedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.ModifiedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new ModifyContentResponse()
            {
                Content = record.Public
            };
        }

        public override async Task<PublishContentResponse> PublishContent(PublishContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new PublishContentResponse();

            if (!(user.IsAdmin || user.IsPublisher))
                return new PublishContentResponse();

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new PublishContentResponse();

            record.Public.PublishedOnUTC = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new PublishContentResponse()
            {
                Content = record.Public
            };
        }

        public override async Task<UnpublishContentResponse> UnpublishContent(UnpublishContentRequest request, ServerCallContext context)
        {
            var user = ONUserHelper.ParseUser(context.GetHttpContext());
            if (user == null)
                return new UnpublishContentResponse();

            if (!(user.IsAdmin || user.IsPublisher))
                return new UnpublishContentResponse();

            var contentId = request.ContentID.ToGuid();
            var record = await dataProvider.GetById(contentId);
            if (record == null)
                return new UnpublishContentResponse();

            record.Public.PublishedOnUTC = null;
            record.Private.PublishedBy = user.Id.ToString();

            await dataProvider.Save(record);

            return new UnpublishContentResponse()
            {
                Content = record.Public
            };
        }
    }
}
