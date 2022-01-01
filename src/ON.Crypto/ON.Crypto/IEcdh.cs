using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ON.Crypto
{
    public interface IEcdh
    {
        public byte[] DeriveKeyClient(ECDsa privKey, JsonWebKey serverPubKey);

        public byte[] DeriveKeyServer(JsonWebKey clientPubKey, out string serverPubKey);
    }
}
