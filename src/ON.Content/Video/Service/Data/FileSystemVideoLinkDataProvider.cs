using Microsoft.Extensions.Options;
using ON.Content.Video.Service.Models;
using ON.Fragments.Content;

namespace ON.Content.Video.Service.Data
{
    public class FileSystemVideoLinkDataProvider : IVideoLinkDataProvider
    {
        private readonly DirectoryInfo videoLinkDir;

        public FileSystemVideoLinkDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            videoLinkDir = root.CreateSubdirectory("video");
        }

        public Task<bool> Delete(Guid linkGuid) { throw new NotImplementedException(); }

        public Task<bool> Exists(Guid linkGuid) { throw new NotImplementedException(); }

        public IAsyncEnumerable<VideoLinkRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<VideoLinkRecord> GetById(Guid linkGuid)
        {
            throw new NotImplementedException();
        }

        public Task Save(VideoLinkRecord videoLinkRecord)
        {
            throw new NotImplementedException();
        }
    }
}
