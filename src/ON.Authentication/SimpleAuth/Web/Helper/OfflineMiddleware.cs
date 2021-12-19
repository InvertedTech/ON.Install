using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Web.Helper
{
    public class OfflineMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly OfflineHelper offlineHelper;

        public OfflineMiddleware(RequestDelegate next, OfflineHelper offlineHelper, ILogger<OfflineMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
            this.offlineHelper = offlineHelper;
        }

        public async Task Invoke(HttpContext context)
        {
            if (offlineHelper.IsOffline)
            {
                // set the code to 503 for SEO reasons
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                //context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                //context.Response.Headers.Add("Retry-After", "60");
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<html><body><h1>Site Offline</h1></body></html>", Encoding.UTF8);
                await context.Response.CompleteAsync();
            }
            await next.Invoke(context);
        }
    }

    public static class OfflineMiddlewareExtensions
    {
        public static IServiceCollection AddOfflineDetection(this IServiceCollection services)
        {
            services.AddSingleton<OfflineHelper>();
            return services;
        }

        public static IApplicationBuilder UseOfflineDetection(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OfflineMiddleware>();
        }
    }
}
