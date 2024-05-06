using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Content
{
    public sealed partial class AudioAssetRecord : pb::IMessage<AudioAssetRecord>
    {
        public Guid AssetIDGuid
        {
            get => Public.AssetIDGuid;
        }

        public AssetListRecord ToAssetListRecord() => Public.ToAssetListRecord();
    }

    public sealed partial class AudioAssetPublicRecord : pb::IMessage<AudioAssetPublicRecord>
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
                AssetType = AssetType.Audio,
                LengthSeconds = Data.LengthSeconds,
            };

            return rec;
        }
    }
}