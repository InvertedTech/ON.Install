using Microsoft.Extensions.Options;
using System.Net.Http;
using RestSharp;
using ON.Content.Video.Service.Models;

namespace ON.Content.Video.Service.Data
{
    public class HttpRumbleProvider : IRumbleProvider
    {
        private readonly AppSettings appSettings;
        private HttpClient client;
        private readonly string RumbleUri;
        private readonly string token;
        public HttpRumbleProvider(IOptions<AppSettings> settings)
        {
            appSettings = settings.Value;
            client = new HttpClient();
            RumbleUri = "https://rumble.com/api/v0/Media.Item";
            token = appSettings.RumblePlatformToken;
        }

        public async Task<HttpResponseMessage> GetRumbleVideo(string videoId)
        {
            var uri = RumbleUri + "/Media.Item?_p=" + token + "&fid=57567802";

            var request = new RestRequest(RumbleUri).AddParameter("access_token", token).AddParameter("fid", 57567802);

            HttpResponseMessage response = await client.GetAsync(uri);
            return response;
        }
    }
}
