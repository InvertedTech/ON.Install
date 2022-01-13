using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Crypto
{
    public static class JwkExtension
    {
        public static JsonWebKey DecodeJsonWebKey(this string encodedJWK)
        {
            return new JsonWebKey(Base64UrlEncoder.Decode(encodedJWK));
        }

        public static JsonWebKey ToPrivateJsonWebKey(this ECDsa eckey)
        {
            var parameters = eckey.ExportParameters(true);

            var jwk = new JsonWebKey()
            {
                Kty = JsonWebAlgorithmsKeyTypes.EllipticCurve,
                Use = "sig",
                X = Base64UrlEncoder.Encode(parameters.Q.X),
                Y = Base64UrlEncoder.Encode(parameters.Q.Y),
                D = Base64UrlEncoder.Encode(parameters.D),
                Crv = JsonWebKeyECTypes.P256,
                Alg = "ES256"
            };

            return jwk;
        }

        public static string ToPrivateEncodedJsonWebKey(this ECDsa eckey)
        {
            return Base64UrlEncoder.Encode(System.Text.Json.JsonSerializer.Serialize(eckey.ToPrivateJsonWebKey()));
        }

        public static JsonWebKey ToPublicJsonWebKey(this ECDsa eckey)
        {
            var parameters = eckey.ExportParameters(false);

            var jwk = new JsonWebKey()
            {
                Kty = JsonWebAlgorithmsKeyTypes.EllipticCurve,
                Use = "sig",
                X = Base64UrlEncoder.Encode(parameters.Q.X),
                Y = Base64UrlEncoder.Encode(parameters.Q.Y),
                Crv = JsonWebKeyECTypes.P256,
                Alg = "ES256"
            };

            return jwk;
        }

        public static string ToPublicEncodedJsonWebKey(this ECDsa eckey)
        {
            return Base64UrlEncoder.Encode(System.Text.Json.JsonSerializer.Serialize(eckey.ToPublicJsonWebKey));
        }
    }
}
