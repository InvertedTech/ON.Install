using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Notification
{
    public sealed partial class NotificationUserRecord : pb::IMessage<NotificationUserRecord>
    {
        private static MD5 hasher = MD5.Create();
        public string TokenHash
        {
            get => GenerateHash(TokenID);
        }

        public Guid UserIDGuid
        {
            get => UserID.ToGuid();
            set => UserID = value.ToString();
        }

        public static string GenerateHash(string str)
        {
            if (str == null)
                return null;

            var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(str));

            var result = BitConverter.ToString(hash).Replace("-", "").ToLower();

            return result;
        }
    }
}
