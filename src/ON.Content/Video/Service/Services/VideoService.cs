using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using ON.Content.Video.Service.Data;
using ON.Content.Video.Service.Validators;
using ON.Fragments.Content;
using ON.Fragments.Generic;

namespace ON.Content.Video.Service
{
    public class VideoService : VideoInterface.VideoInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly IVideoLinkDataProvider dataProvider;
        private readonly IRumbleProvider rumbleProvider;
        private readonly RumbleValidator rumbleValidator;

        public VideoService(ILogger<ServiceOpsService> logger, IVideoLinkDataProvider dataProvider, IRumbleProvider rumbleProvider)
        {
            this.logger = logger;
            this.dataProvider = dataProvider;
            this.rumbleProvider = rumbleProvider;
            this.rumbleValidator = new RumbleValidator();
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

            var res = await rumbleProvider.GetRumbleVideo("123");
            logger.LogWarning($"***LinkVideo: {res.Content.ToString()}***");

            var ledger = await dataProvider.GetAll();

            if (ledger == null)
            {
                ledger = new VideoLinkLedger();
            }

            ledger.VideoLinks.Add(link);


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

        public override async Task<GetLinkResponse> GetVideoLink(GetLinkRequest request, ServerCallContext context)
        {
            VideoLink videoLink = await dataProvider.GetById(request.VideoGuid.ToGuid());
            logger.LogWarning($"***GETBYID: {videoLink} ***");


            if (videoLink == null) { return new GetLinkResponse() { Success = false }; }

            logger.LogWarning($"***GETBYID: {videoLink} ***");

            return new GetLinkResponse()
            {
                Success = true,
                LinkedVideo = videoLink,
            };
        }

        // TODO: Figure out the problem with why this doesn't return the proper values but still deletes
        public override async Task<UnlinkVideoResponse> UnlinkVideo(UnlinkVideoRequest request, ServerCallContext context)
        {
            VideoLinkLedger ledger = await dataProvider.Delete(request.LinkGUID.ToGuid());


            return new UnlinkVideoResponse()
            {
                Success = true,
                Ledger = ledger
            };
        }

        public override async Task<RumbleResponse> GetRumble(RumbleRequest rumbleRequest, ServerCallContext context)
        {
            logger.LogWarning($"REQUEST: {rumbleRequest}");
            //var isValidLanguage = await rumbleValidator.IsValidLanguageAsync(rumbleRequest.Language);
            //var isValidExtension = await rumbleValidator.IsValidExtension(rumbleRequest.Ext);
            //var isValidSort = await rumbleValidator.IsValidSort(rumbleRequest.Criteria.Sort);
            //var isValidSyndicated = await rumbleValidator.IsValidNumber(((int)rumbleRequest.Syndicated), 0, 1);
            var isValidRequest = await rumbleValidator.IsValidQuery(rumbleRequest.Query);
            logger.LogWarning($"***VALIDATE REQUEST: {isValidRequest}");
            if (!isValidRequest) { return new RumbleResponse() { Success = false }; }

            return new RumbleResponse()
            {
                Success = true
            };
        }
    }
}
