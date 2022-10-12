using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public interface IAssetDataProvider
    {
        IAsyncEnumerable<AssetRecord> GetAll();
        Task<AssetRecord> GetById(Guid assetId);
        Task<AssetRecord> GetByOldAssetId(string oldAssetId);
        Task<bool> Delete(Guid assetId);
        Task<bool> Exists(Guid assetId);
        Task Save(AssetRecord asset);
    }
}
