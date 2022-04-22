using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.Video.Service.Models;
using ON.Fragments.Content;
using ON.Fragments.Generic;

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

        public Task<bool> Delete(Guid linkGuid) { 
            var fd = GetVideoFilePath(linkGuid);
            var res = fd.Exists;
            fd.Delete();
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid linkGuid) {
            var fd = GetVideoFilePath(linkGuid);
            return Task.FromResult(fd.Exists);
        }

        public IAsyncEnumerable<VideoLink> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<VideoLink> GetById(Guid linkGuid)
        {
            throw new NotImplementedException();
        }

        public async Task Save(VideoLink video)
        {
            var linkGuid = video.LinkGUID.ToGuid();
            var fd = GetVideoFilePath(linkGuid);
            await File.WriteAllBytesAsync(fd.FullName, video.ToByteArray());
        }

        private FileInfo GetVideoFilePath(Guid videoGuid)
        {
            var name = videoGuid.ToString();
            return new FileInfo(videoLinkDir.FullName + "/" + name);
        }
    }
}
