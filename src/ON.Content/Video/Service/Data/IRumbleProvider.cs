namespace ON.Content.Video.Service.Data
{
    public interface IRumbleProvider
    {
        Task<HttpResponseMessage> GetRumbleVideo(string videoId);
    }
}
