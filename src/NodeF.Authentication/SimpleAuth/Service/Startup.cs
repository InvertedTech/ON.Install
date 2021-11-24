using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NodeF.Authentication.SimpleAuth.Service.Data;
using NodeF.Authentication.SimpleAuth.Service.Helper;
using NodeF.Authentication.SimpleAuth.Service.Models;
using NodeF.Authentication.SimpleAuth.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Service
{
    public class Startup
    {
        private static byte[] PONG_RESPONSE = { (byte)'p', (byte)'o', (byte)'n', (byte)'g' };

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IUserDataProvider, FileSystemUserDataProvider>();
            services.AddScoped<ClaimsClient>();
            services.AddSingleton<ServiceNameHelper>();

            services.AddJwtAuthentication();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/ping", (app1) => app1.Run(async context => {
                await context.Response.BodyWriter.WriteAsync(PONG_RESPONSE);
            }));

            app.UseRouting();

            app.UseJwtAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ServiceOpsService>();
                endpoints.MapGrpcService<UserService>();
            });
        }
    }
}
