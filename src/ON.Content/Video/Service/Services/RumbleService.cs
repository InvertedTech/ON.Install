using Grpc.Core;
using ON.Fragments.Content;
using ON.Content.Video.Service.Data;
using ON.Content.Video.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

// Todo: Add Authentication
// Todo: Error Handling
// Todo: Change Save Path based on each channel
// Todo: Handle Duplicates
// Todo: Handle Date Range Filter
// Todo: Refactor the internal classes to /Models
namespace ON.Content.Video.Service
{
    public class RumbleService : RumbleInterface.RumbleInterfaceBase
    {
        private readonly ILogger<ServiceOpsService> logger;
        private HttpRumbleProvider httpRumble;
        private readonly IOptions<AppSettings> appSettings;
        private readonly IFileSystemRumbleProvider rumbleDataProvider;

        public RumbleService(ILogger<ServiceOpsService> logger, IOptions<AppSettings> settings, IFileSystemRumbleProvider dataProvider)
        {
            this.logger = logger;
            appSettings = settings;
            httpRumble = new HttpRumbleProvider(logger, appSettings);
            rumbleDataProvider = dataProvider;
        }
        public override async Task<RumbleChannelResponse> GetRumbleChannel(RumbleChannelRequest request, ServerCallContext context)
        {
            RumbleData data = new RumbleData();

            var httpResponse = await httpRumble.MediaSearchRequest(request);
            var body = httpResponse.Content;

            if (body != null)
            {
                try
                {
                    var deserialized = JsonConvert.DeserializeObject<ResponseMapping>(body);
                    Paginate pagination = deserialized.paginate;
                    Criteria criteria = deserialized.criteria;
                    Result[] results = deserialized.results;

                    if (criteria.pg < pagination.pages)
                    {
                        // Initiate the paginated request
                        //logger.LogWarning(body);
                        var totalPages = pagination.pages;
                        RumbleData tmpData = await GetAllResults(request, totalPages, httpRumble);
                        data.Videos.Add(tmpData.Videos);

                        //logger.LogWarning($"DATALEN::::{data.Videos.Count}");
                        //logger.LogWarning($"DATALENREQ::::{pagination.items}");

                        await rumbleDataProvider.SaveData(data);
                        return new RumbleChannelResponse
                        {
                            Success = true,
                            Msg = "Got all data",
                            Data = data
                        };

                    }
                    else
                    {
                        foreach (Result result in results)
                        {
                            var video = new RumbleVideo
                            {
                                Id = result.fid,
                                Embed = result.video.iframe,
                                Title = result.title,
                                IsPrivate = result.isprivate,
                                Channel = request.ChannelId
                            };

                            data.Videos.Add(video);
                        }

                        await rumbleDataProvider.SaveData(data);
                        return new RumbleChannelResponse
                        {
                            Success = true,
                            Msg = "Rumble Channel found for " + request.ChannelId,
                            Data = data
                        };
                    }
                }
                catch (Exception ex)
                {
                    return new RumbleChannelResponse
                    {
                        Success = false,
                        Msg = "No Channel Found: " + ex.Message,
                    };
                }
            }

            return new RumbleChannelResponse
            {
                Success = false,
                Msg = "Uknown Error Occured"
            };
        }

        public override async Task<StoredDataResponse> GetAllStoredData(EmptyRequest request, ServerCallContext context)
        {
            var data = await rumbleDataProvider.GetData();

            if (data != null)
            {
                return new StoredDataResponse
                {
                    Success = true,
                    Msg = "Stored Rumble Data Found",
                    Data = data
                };
            }

            return new StoredDataResponse
            {
                Success = false,
                Msg = "Stored Rumble Data Not Found",
            };
        }

        private async Task<RumbleData> GetAllResults(RumbleChannelRequest request, int totalPages, HttpRumbleProvider rumble)
        {
            RumbleData data = new RumbleData();


            for (int i = 1; i <= totalPages; i++)
            {
                var httpResponse = await rumble.MediaSearchRequestPaginated(request, i.ToString());
                var body = httpResponse.Content;
                var deserialized = JsonConvert.DeserializeObject<ResponseMapping>(body);
                Result[] pgResults = deserialized.results;

                foreach (Result result in pgResults)
                {
                    var video = new RumbleVideo
                    {
                        Id = result.fid,
                        Embed = result.video.iframe,
                        Title = result.title,
                        IsPrivate = result.isprivate,
                        Channel = request.ChannelId
                    };

                    data.Videos.Add(video);
                }
            }

            return data;
        }

    }

    internal class ResponseMapping
    {
        public Result[] results { get; set; }
        public Paginate paginate { get; set; }
        public Criteria criteria {  get; set; }
    }

    internal class Criteria
    {
        public bool ugc { get; set; }
        public int pg { get; set; }
        public bool sort { get; set; }
        public int limit { get; set; }
        public int days { get; set; }
    }

    internal class Paginate
    {
        public int current { get; set; }
        public int pages { get; set; }
        public int items { get; set; }
    }

    internal class Result
    {
        public string fid { get; set; }
        public string title { get; set; }
        public dynamic video { get; set; }
        public bool isprivate { get; set; }

    }
}
