using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Content
{
    public sealed partial class ImageAssetRecord : pb::IMessage<ImageAssetRecord>
    {
        public Guid AssetIDGuid
        {
            get => Public.AssetIDGuid;
        }
    }

    public sealed partial class ImageAssetPublicRecord : pb::IMessage<ImageAssetPublicRecord>
    {
        public Guid AssetIDGuid
        {
            get => AssetID.ToGuid();
            set => AssetID = value.ToString();
        }

        public AssetListRecord ToAssetListRecord()
        {
            var rec = new AssetListRecord()
            {
                AssetID = AssetID,
                CreatedOnUTC = CreatedOnUTC,
                Title = Data.Title,
                Caption = Data.Caption,
                AssetType = AssetType.Image,
                Height = Data.Height,
                Width = Data.Width,
            };

            return rec;
        }
    }
}