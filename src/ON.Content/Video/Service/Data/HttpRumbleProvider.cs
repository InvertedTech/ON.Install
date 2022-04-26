using Microsoft.Extensions.Options;
using System.Net.Http;
using RestSharp;
using ON.Content.Video.Service.Models;
using ON.Fragments.Content;

namespace ON.Content.Video.Service.Data
{
    public class HttpRumbleProvider : IRumbleProvider
    {
        private readonly AppSettings appSettings;
        private RestClient client;
        private readonly string RumbleUri;
        private readonly string token;
        public HttpRumbleProvider(IOptions<AppSettings> settings)
        {
            appSettings = settings.Value;
            client = new RestClient();
            RumbleUri = "https://rumble.com/api/v0/";
            token = appSettings.RumblePlatformToken;
        }

        public async Task<RestResponse> GetRumbleVideo(RumbleRequest rumbleRequest)
        {
            var uri = RumbleUri + rumbleRequest.RequestType;

            var request = new RestRequest(uri);
            request.AddQueryParameter("_p", token);

            if (rumbleRequest.RequestType == "Media.Item") {
                request.AddQueryParameter("fid", rumbleRequest.FId);

                var response = await client.GetAsync(request);
                return response;
            } else {
                throw new NotImplementedException();
            }
        }
    }
}
