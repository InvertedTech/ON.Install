using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NodeF.Authentication
{
    public class JwtCookieToBearerMiddleware
    {
        private readonly RequestDelegate next;

        public JwtCookieToBearerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                string token = context.Request.Cookies[JwtExtensions.JWT_COOKIE_NAME];

                if (token != null)
                    context.Request.Headers.Add("Authorization", "Bearer " + token);
            }

            await next(context);
        }
    }
}
