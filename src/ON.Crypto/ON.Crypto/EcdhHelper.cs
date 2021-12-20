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
        public static byte[] DeriveKeyClient(ECDsa privKey, JsonWebKey serverPubKey)
        {
            var param = privKey.ExportParameters(true);
            using ECDiffieHellmanCng privECDH = new();
            privECDH.ImportParameters(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                D = param.D
            });

            using ECDiffieHellmanCng pubECDH = new();
            pubECDH.ImportParameters(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                Q = new ECPoint()
                {
                    X = Base64UrlEncoder.DecodeBytes(serverPubKey.X),
                    Y = Base64UrlEncoder.DecodeBytes(serverPubKey.Y),
                }
            });

            return privECDH.DeriveKeyMaterial(pubECDH.PublicKey);
        }

        public static byte[] DeriveKeyServer(JsonWebKey clientPubKey, out string serverPubKey)
        {
            ECDsa privKey = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            serverPubKey = privKey.ToPublicEncodedJsonWebKey();

            var param = privKey.ExportParameters(true);
            using ECDiffieHellmanCng privECDH = new();
            privECDH.ImportParameters(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                D = param.D
            });

            using ECDiffieHellmanCng pubECDH = new();
            pubECDH.ImportParameters(new ECParameters()
            {
                Curve = ECCurve.NamedCurves.nistP256,
                Q = new ECPoint()
                {
                    X = Base64UrlEncoder.DecodeBytes(clientPubKey.X),
                    Y = Base64UrlEncoder.DecodeBytes(clientPubKey.Y),
                }
            });

            return privECDH.DeriveKeyMaterial(pubECDH.PublicKey);
        }
    }
}
