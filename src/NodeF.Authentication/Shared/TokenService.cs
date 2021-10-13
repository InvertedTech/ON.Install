using System.Buffers.Text;
using System.Text;
using System.Security.Cryptography;
using System;
using System.Collections.Concurrent;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace NodeF.Authentication
{
    public class TokenService
    {
        public const string JWT_PRIVATE_KEY_ENVIRONMENT_NAME = "JWT_PRIV_KEY";
        public const string JWT_PUBLIC_KEY_ENVIRONMENT_NAME = "JWT_PUB_KEY";

        private IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler tokenHandler;
        private readonly TokenValidationParameters tokenParams;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            tokenHandler = new JwtSecurityTokenHandler();

            tokenParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetPublicKey(),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
        }

        public static JsonWebKey GetPrivateKey()
        {
            return GetKeyFromEnvVar(JWT_PRIVATE_KEY_ENVIRONMENT_NAME);
        }

        public static JsonWebKey GetPublicKey()
        {
            return GetKeyFromEnvVar(JWT_PUBLIC_KEY_ENVIRONMENT_NAME);
        }

        private static JsonWebKey GetKeyFromEnvVar(string keyName)
        {
            var envKey = Environment.GetEnvironmentVariable(keyName, EnvironmentVariableTarget.Process);
            if (envKey == null)
                throw new Exception($"Environment variable not found {keyName}");

            return new JsonWebKey(Base64UrlEncoder.Decode(envKey)); ;
        }

        public AuthenticationTicket ValidateToken(string token)
        {
            return ParseToken(token);
        }

        private AuthenticationTicket ParseToken(string token)
        {
            try
            {
                tokenHandler.ValidateToken(token, tokenParams, out SecurityToken validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                // attach user to context on successful jwt validation
                if (jwtToken != null)
                {
                    var user = NodeUser.Parse(jwtToken.Claims);
                    user.JwtToken = token;

                    return CreateAuthenticationTicket(user);
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }

            return null;
        }

        private AuthenticationTicket CreateAuthenticationTicket(NodeUser user)
        {
            ClaimsPrincipal claimsPrincipal = user;
            AuthenticationTicket authTicket = new AuthenticationTicket(claimsPrincipal, TokenAuthenticationSchemeOptions.Name);

            return authTicket;
        }
    }
}
