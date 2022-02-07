using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Fragments.Generic
{
    public static class GenericExtensions
    {
        public static ByteString ToByteString(this Guid id)
        {
            return ByteString.CopyFrom(id.ToByteArray());
        }

        public static Guid ToGuid(this ByteString id)
        {
            return new Guid(id.Span);
        }
    }
}
