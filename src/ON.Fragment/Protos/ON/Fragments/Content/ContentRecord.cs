using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Content
{
    public sealed partial class ContentRecord : pb::IMessage<ContentRecord>
    {
        public static partial class Types
        {
            public sealed partial class PublicData : pb::IMessage<PublicData>
            {
                public Guid ContentIDGuid
                {
                    get => ContentID.ToGuid();
                    set => ContentID = value.ToString();
                }
            }
        }
    }
}