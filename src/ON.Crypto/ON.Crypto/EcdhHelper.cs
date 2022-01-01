using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ON.Crypto
{
    public static class EcdhHelper
    {
        private static IEcdh ecdh;

        static EcdhHelper()
        {
            if (OperatingSystem.IsWindows())
                ecdh = new EcdhHelperWindows();
            else
                ecdh = new EcdhHelperLinux();
        }

        public static byte[] DeriveKeyClient(ECDsa privKey, JsonWebKey serverPubKey)
        {
            return ecdh.DeriveKeyClient(privKey, serverPubKey);
        }

        public static byte[] DeriveKeyServer(JsonWebKey clientPubKey, out string serverPubKey)
        {
            return ecdh.DeriveKeyServer(clientPubKey, out serverPubKey);
        }
    }
}
