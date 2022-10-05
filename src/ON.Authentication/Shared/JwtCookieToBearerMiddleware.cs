using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace ON.Authentication
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

            var user = ONUserHelper.ParseUser(context);
            if (user != null)
            {
                Console.WriteLine($"**** {user.UserName} - {string.Join(',', user.Roles)} ****");
            }
        }
    }
}
