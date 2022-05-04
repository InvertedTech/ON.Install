using Grpc.Core;
using ON.Fragments.Content;
using ON.Content.Rumble.Service.Data;
using ON.Content.Rumble.Service.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ON.Authentication;

// Todo: Error Handling
// Todo: Handle Date Range Filter
// Todo: Maybe Deserialize on the HttpRumbleProvider to return cleaner responses
namespace ON.Content.Rumble.Service
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
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new RumbleChannelResponse() { Error = "No user token specified" };
            if (!userToken.IsWriterOrHigher) { return new RumbleChannelResponse() { Error = "Access Denied, Wrong Permissions" }; }

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

                        foreach (RumbleVideo item in tmpData.Videos)
                        {
                            var isDuplicate = await rumbleDataProvider.IsDuplicateVideo(item.Id);

                            if (isDuplicate)
                            {
                                logger.LogWarning($"%%%% Video Duplicate {isDuplicate}");
                                continue;
                            } else
                            {
                                data.Videos.Add(item);
                            }
                        }

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
                            bool isDuplicate = await rumbleDataProvider.IsDuplicateVideo(result.fid);

                            if (isDuplicate)
                            {
                                logger.LogWarning($"%%%% Video Duplicate {isDuplicate}");
                              continue;
                            } else
                            {
                                RumbleVideo video = new RumbleVideo
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
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new StoredDataResponse() { Error = "No user token specified" };
            if (!userToken.IsWriterOrHigher) { return new StoredDataResponse() { Error = "Access Denied, Wrong Permissions" }; }

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

        public override async Task<StoredDataResponse> GetStoredDataById(StoredDataRequest request, ServerCallContext context)
        {
            var userToken = ONUserHelper.ParseUser(context.GetHttpContext());
            if (userToken == null)
                return new StoredDataResponse() { Error = "No user token specified" };
            if (!userToken.IsWriterOrHigher) { return new StoredDataResponse() { Error = "Access Denied, Wrong Permissions" }; }

            RumbleData data = await rumbleDataProvider.GetData();

            if (data != null)
            {
                foreach (var item in data.Videos)
                {
                    if (item == null) {
                        {
                            return new StoredDataResponse
                            {
                                Success = false,
                                Msg = "Stored Rumble Data Not Found",
                            };
                        } }

                    if (item.Id == request.VideoId)
                    {
                        StoredDataResponse response = new StoredDataResponse
                        {
                            Success = true,
                            Msg = "Stored Rumble Data Found",
                            Data = new RumbleData()
                        };

                        response.Data.Videos.Add(item);

                        return response;
                    }
                }
                
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
}
