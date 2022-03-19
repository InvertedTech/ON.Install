using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Authentication
{
    public sealed partial class UserRecord : pb::IMessage<UserRecord>
    {
        public static partial class Types
        {
            public sealed partial class PublicData : pb::IMessage<PublicData>
            {
                public Guid UserIDGuid 
                {
                    get => UserID.ToGuid();
                    set => UserID = value.ToString();
                }
            }
        }
    }
}