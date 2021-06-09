using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NodeF.Authentication
{
    public class JwtValidatorMiddleware
    {
        public const string JWT_PRIVATE_KEY_ENVIRONMENT_NAME = "JWT_PRIV_KEY";
        public const string JWT_PUBLIC_KEY_ENVIRONMENT_NAME = "JWT_PUB_KEY";
        public const string JWT_COOKIE_NAME = "token";

        private readonly RequestDelegate next;
        private readonly JwtSecurityTokenHandler tokenHandler;
        private readonly TokenValidationParameters tokenParams;

        public JwtValidatorMiddleware(RequestDelegate next)
        {
            this.next = next;

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

        public async Task Invoke(HttpContext context)
        {
            string token = GetTokenFromHeaderOrCookie(context);

            if (token != null)
                attachUserToContext(context, token);

            await next(context);
        }

        private string GetTokenFromHeaderOrCookie(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();
            if (token != null)
                return token;

            return context.Request.Cookies[JWT_COOKIE_NAME];
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

        private void attachUserToContext(HttpContext context, string token)
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
                    context.User = user;
                }
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
