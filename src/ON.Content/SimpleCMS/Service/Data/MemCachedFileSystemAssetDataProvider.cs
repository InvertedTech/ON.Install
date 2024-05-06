using ON.Fragments.Content;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using System.Linq;

namespace ON.Content.SimpleCMS.Service.Data
{
    public class MemCachedFileSystemAssetDataProvider : IAssetDataProvider
    {
        private readonly ConcurrentDictionary<Guid, AssetListRecord> cache = new();
        private readonly FileSystemAssetDataProvider dataProvider;

        public MemCachedFileSystemAssetDataProvider(FileSystemAssetDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            LoadCache().Wait();
        }

        private async Task LoadCache()
        {
            await foreach(var r in dataProvider.GetAll())
            {
                cache.TryAdd(r.AssetIDGuid, r.ToAssetListRecord());
            }
        }

        public IAsyncEnumerable<AssetRecord> GetAll()
        {
            return dataProvider.GetAll();
        }

        public IAsyncEnumerable<AssetListRecord> GetAllShort()
        {
            return cache.Values.Select(v => v).ToAsyncEnumerable();
        }

        public Task<AssetRecord> GetById(Guid assetId)
        {
            return dataProvider.GetById(assetId);
        }

        public Task<AssetRecord> GetByOldAssetId(string oldAssetId)
        {
            return dataProvider.GetByOldAssetId(oldAssetId);
        }

        public Task<bool> Delete(Guid assetId)
        {
            cache.TryRemove(assetId, out var dummy);
            return dataProvider.Delete(assetId);
        }

        public Task<bool> Exists(Guid assetId)
        {
            return dataProvider?.Exists(assetId);
        }

        public Task Save(AssetRecord asset)
        {
            cache[asset.AssetIDGuid] = asset.ToAssetListRecord();
            return dataProvider.Save(asset);
        }
    }
}
