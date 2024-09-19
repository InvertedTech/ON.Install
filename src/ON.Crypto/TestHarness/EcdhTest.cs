using ON.Crypto;
using ON.Crypto.Extra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestHarness
{
    class EcdhTest
    {
        public static void Test()
        {
            var derive = new TheGreatDerivator(TheGreatDerivator.GenerateNewMnemonic());

            var clientKey = derive.DeriveBackupKey();
            string privKey = clientKey.ToPrivateEncodedJsonWebKey();
            string clientPubKey = clientKey.ToPublicEncodedJsonWebKey();

            var serverBytes = EcdhHelper.DeriveKeyServer(clientPubKey.DecodeJsonWebKey(), out string serverPubKey);
            var clientBytes = EcdhHelper.DeriveKeyClient(clientKey, serverPubKey.DecodeJsonWebKey());
        }
    }
}
