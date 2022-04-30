using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ON.Content.Video.Service.Models;
using ON.Fragments.Content;
using RestSharp;
using System.Text.Json;

namespace ON.Content.Video.Service.Data
{
    public class HttpRumbleProvider
    {
        private readonly ILogger<ServiceOpsService> logger;
        private readonly IOptions<AppSettings> appSettings;
        private readonly string RumbleUri;
        public HttpRumbleProvider(ILogger<ServiceOpsService> logger, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            RumbleUri = "https://rumble.com/api/v0";
            appSettings = settings;
        }

        private async Task<RestResponse> MakeHttpRequest(RestRequest request)
        {
            var client = new RestClient();
            var response = await client.GetAsync(request);
            
            return response;
        }

        public async Task<RestResponse> MediaItemRequest(RumbleVideoIdRequest request)
        {
            var uri = RumbleUri + "/Media.Item?_p=" + appSettings.Value.RumblePlatformToken;
            RestRequest req = new RestRequest(uri);
            req.AddHeader("ContentType", "application/json");
            var reqParams = new
            {
                fid = request.Fid,
            };
            req.AddObject(reqParams);
            RestResponse resp = await MakeHttpRequest(req);

            return resp;
        }

        public async Task<RestResponse> MediaSearchRequest(RumbleVideoRequest request)
        {
            var uri = RumbleUri + "/Media.Search?_p=" + appSettings.Value.RumblePlatformToken;
            RestRequest req = new RestRequest(uri);
            req.AddHeader("ContentType", "application/json");

            var reqParams = new
            {
                lang = request.Lang,
                syndicated = request.Syndicated,
                channel = request.ChannelCase,
                user = request.UserCase,
                ext = request.Ext,
                debug = request.Debug,
                criteria = request.CriteriaCase
            };
            req.AddObject(reqParams);
            RestResponse response = await MakeHttpRequest(req);

            return response;
        }

        public async Task<RestResponse> MediaSearchRequest(RumbleChannelRequest request)
        {
            var uri = RumbleUri + "/Media.Search?_p=" + appSettings.Value.RumblePlatformToken;
            var req = new RestRequest(uri);
            req.AddHeader("ContentType", "application/json");
            req.AddParameter("channel", request.ChannelId);
            var response = await MakeHttpRequest(req);
            return response;
        }
    }
}
