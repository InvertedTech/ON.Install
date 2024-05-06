using ON.Authentication;
using ON.Fragments.Content;
using ON.SimpleWeb.Models.CMS;
using System.Collections.Generic;

namespace ON.SimpleWeb.Models.Asset
{
    public class ImageSearchViewModel
    {
        public ImageSearchViewModel() { }

        public ImageSearchViewModel(SearchAssetResponse assetResponse)
        {
            if (assetResponse?.Records == null)
                return;
            Records.AddRange(assetResponse.Records);
        }

        public List<AssetListRecord> Records { get; } = new List<AssetListRecord>();
        public PageNumViewModel PageVM { get; set; } = null;
    }
}
