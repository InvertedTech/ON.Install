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
        private readonly FileInfo videoLinkLedger;

        public FileSystemVideoLinkDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            videoLinkDir = root.CreateSubdirectory("video");
            videoLinkLedger = new FileInfo(videoLinkDir.FullName + "/links");
        }

        public Task<bool> Delete(Guid linkGuid) { 
            var fd = GetVideoFilePath(linkGuid);
            var res = fd.Exists;
            try
            {
                fd.Delete();
            } catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid linkGuid) {
            var fd = GetVideoFilePath(linkGuid);
            return Task.FromResult(fd.Exists);
        }

        public async Task<VideoLinkLedger> GetAll()
        {
            if (!videoLinkLedger.Exists) { return new VideoLinkLedger(); }

            var bytes = await File.ReadAllBytesAsync(videoLinkLedger.FullName);

            return VideoLinkLedger.Parser.ParseFrom(bytes);
        }

        public async Task<VideoLink> GetById(Guid linkGuid)
        {
            var fd = GetVideoFilePath(linkGuid);
            if (!fd.Exists) { return null; }

            return VideoLink.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task SaveAll(VideoLinkLedger ledger)
        {
            await File.WriteAllBytesAsync(videoLinkLedger.FullName, ledger.ToByteArray());
        }

        private FileInfo GetVideoFilePath(Guid videoGuid)
        {
            var name = videoGuid.ToString();
            return new FileInfo(videoLinkDir.FullName + "/" + name);
        }
    }
}
