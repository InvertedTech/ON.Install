using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.Video.Service.Models;
using ON.Fragments.Content;

namespace ON.Content.Video.Service.Data
{
    public class FileSystemRumbleProvider : IFileSystemRumbleProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly FileInfo listFile;

        public FileSystemRumbleProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("links");
            listFile = new FileInfo(dataDir.FullName + "/rumble-data");
        }

        public async Task<RumbleData> GetData()
        {
            if (!listFile.Exists)
            {
                return new RumbleData();
            }

            var bytes = await File.ReadAllBytesAsync(listFile.FullName);
            return RumbleData.Parser.ParseFrom(bytes);
        }

        public async Task SaveData(RumbleData data)
        {
            await File.WriteAllBytesAsync(listFile.FullName, data.ToByteArray());
        }
    }
}
