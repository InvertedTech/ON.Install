using ON.Fragments.Content;

namespace ON.Content.Video.Service.Models
{
    public interface IFileSystemRumbleProvider
    {
        Task<RumbleData> GetData();
        Task SaveData(RumbleData data);
    }
}
