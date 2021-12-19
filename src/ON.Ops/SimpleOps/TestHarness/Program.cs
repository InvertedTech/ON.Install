using Microsoft.IdentityModel.Tokens;
using ON.Authentication;
using ON.Crypto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;

namespace TestHarness
{
    class Program
    {
        public static string JwtToken;

        static void Main(string[] args)
        {
            JwtToken = GenerateToken();

            ECDsa clientKey = ECDsa.Create(ECCurve.NamedCurves.nistP256);
            var clientPubKey = clientKey.ToPublicEncodedJsonWebKey();

            AuthenticationBackupClient client = new();
            var data = client.GetBackup(clientPubKey).Result;
            client.RestoreFromBackup(ON.Fragments.Authentcation.RestoreAllDataRequest.Types.RestoreMode.Wipe, clientKey, data).Wait();

            //using (var wc = new WebClient())
            //{
            //    wc.Headers["Accept"] = "application/octet-stream";
            //    wc.Headers["Authorization"] = "Bearer " + Program.JwtToken;
            //    var res = wc.UploadDataTaskAsync(new Uri("http://localhost:8080/ops/online"), new byte[0]).Result;
            //}

        }

        private static string GenerateToken()
        {
            var key = JwtExtensions.GetPrivateKey();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.EcdsaSha256)
            };

            tokenDescriptor.Claims = new Dictionary<string, object>();
            tokenDescriptor.Claims.Add(ONUser.IdType, Guid.NewGuid().ToString());
            tokenDescriptor.Claims.Add(ClaimTypes.Role, "ops");

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
