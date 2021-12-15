using Microsoft.IdentityModel.Tokens;
using NodeF.Authentication;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TestHarness
{
    class Program
    {
        public static string JwtToken;

        static void Main(string[] args)
        {
            JwtToken = GenerateToken();

            AuthenticationBackupClient client = new();
            var data = client.GetBackup().Result;
            client.SetMode().Wait();
            client.RestoreFromBackup(data).Wait();
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
            tokenDescriptor.Claims.Add(NodeUser.IdType, Guid.NewGuid().ToString());
            tokenDescriptor.Claims.Add(ClaimTypes.Role, "backup");

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
