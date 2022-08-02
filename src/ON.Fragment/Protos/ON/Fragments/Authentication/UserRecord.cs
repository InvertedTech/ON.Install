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
        public Guid UserIDGuid
        {
            get => Normal.Public.UserIDGuid;
            set => Normal.Public.UserIDGuid = value;
        }
    }

    public sealed partial class UserNormalRecord : pb::IMessage<UserNormalRecord>
    {
        public Guid UserIDGuid
        {
            get => Public.UserIDGuid;
            set => Public.UserIDGuid = value;
        }
    }

    public sealed partial class UserPublicRecord : pb::IMessage<UserPublicRecord>
    {
        public Guid UserIDGuid
        {
            get => UserID.ToGuid();
            set => UserID = value.ToString();
        }
    }
}
