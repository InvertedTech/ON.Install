using ON.Fragments.Content;

namespace ON.Content.Video.Service.Data
{
    public interface IVideoLinkDataProvider
    {
        Task<VideoLinkLedger> GetAll();
        Task<VideoLink> GetById(Guid linkGuid);
        Task<bool> Delete(Guid linkGuid);
        Task<bool> Exists(Guid linkGuid);
        Task SaveAll(VideoLinkLedger ledger);
    }
}
