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
        public static Guid ToGuid(this string id)
        {
            return new Guid(id);
        }
    }
}
