using ON.Fragments.Content;
using RestSharp;

namespace ON.Content.Video.Service.Data
{
    public interface IRumbleProvider
    {
        Task<RestResponse> GetRumbleVideo(RumbleRequest rumbleRequest);
    }
}
