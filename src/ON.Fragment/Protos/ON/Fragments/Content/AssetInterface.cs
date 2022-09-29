using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Content
{
    public sealed partial class AssetRecord : pb::IMessage<AssetRecord>
    {
        public Guid AssetIDGuid
        {
            get
            {
                switch (AssetRecordOneofCase)
                {
                    case AssetRecordOneofOneofCase.Audio:
                        return Audio.AssetIDGuid;
                    case AssetRecordOneofOneofCase.Image:
                        return Image.AssetIDGuid;
                    default:
                        return Guid.Empty;
                }
            }
        }

        public string OldAssetId
        {
            get
            {
                switch (AssetRecordOneofCase)
                {
                    case AssetRecordOneofOneofCase.Audio:
                        return Audio.Private?.Data?.OldAssetID ?? "";
                    case AssetRecordOneofOneofCase.Image:
                        return Image.Private?.Data?.OldAssetID ?? "";
                    default:
                        return "";
                }
            }
        }
    }
}