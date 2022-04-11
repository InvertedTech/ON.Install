using Newtonsoft.Json;
using ON.Fragments.Content;
using System.Text.Json;

namespace ON.Content.SimpleCMS.Service.Helpers
{
    public class RumbleHelpers
    {
        public RumbleHelpers() { }

        public string RequestToJson(UploadVideoRumbleRequest request)
        {
            var data = JsonConvert.SerializeObject(request);

            return data;
        }
    }
}
