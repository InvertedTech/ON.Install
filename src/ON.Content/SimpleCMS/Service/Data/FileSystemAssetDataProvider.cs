using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.SimpleCMS.Service.Models;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Service.Data
{
    public class FileSystemAssetDataProvider : IAssetDataProvider
    {
        private readonly DirectoryInfo assetDir;

        public FileSystemAssetDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            assetDir = root.CreateSubdirectory("asset");
        }

        public Task<bool> Delete(Guid assetId)
        {
            var fd = GetContentFilePath(assetId);
            var res = fd.Exists;
            fd.Delete();
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid assetId)
        {
            var fd = GetContentFilePath(assetId);
            return Task.FromResult(fd.Exists);
        }

        public async IAsyncEnumerable<AssetRecord> GetAll()
        {
            foreach (var file in assetDir.GetFiles())
            {
                yield return AssetRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(file.FullName));
            }
        }

        public async Task<AssetRecord> GetById(Guid assetId)
        {
            var fd = GetContentFilePath(assetId);
            if (!fd.Exists)
                return null;

            return AssetRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<AssetRecord> GetByOldAssetId(string oldAssetId)
        {
            await foreach (var rec in GetAll())
            {
                if (rec.OldAssetId == oldAssetId)
                    return rec;
            }

            return null;
        }

        public async Task Save(AssetRecord asset)
        {
            var id = asset.AssetIDGuid;
            var fd = GetContentFilePath(id);
            await File.WriteAllBytesAsync(fd.FullName, asset.ToByteArray());
        }

        private FileInfo GetContentFilePath(Guid assetId)
        {
            var name = assetId.ToString();
            return new FileInfo(assetDir.FullName + "/" + name);
        }
    }
}
