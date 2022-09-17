using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ON.Authentication.SimpleAuth.Service.Data;
using ON.Authentication.SimpleAuth.Service.Helpers;
using ON.Authentication.SimpleAuth.Service.Models;
using ON.Authentication.SimpleAuth.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service
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
            //services.AddGrpc();
            services.AddGrpcHttpApi();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("auth", new OpenApiInfo { Title = "SimpleAuth API" });
            });
            services.AddGrpcSwagger();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IUserDataProvider, FileSystemUserDataProvider>();
            services.AddScoped<ClaimsClient>();
            services.AddSingleton<ServiceNameHelper>();
            services.AddSingleton<OfflineHelper>();

            services.AddJwtAuthentication();

            Console.WriteLine("*** Loading pubkey: ("+ JwtExtensions.GetPublicKey()+ ")  ***");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/ping", (app1) => app1.Run(async context => {
                await context.Response.BodyWriter.WriteAsync(PONG_RESPONSE);
            }));

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/auth/swagger.json", "SimpleAuth API");
                c.RoutePrefix = "api/auth";
            });

            if (env.IsDevelopment())
                Program.IsDevelopment = true;

            app.UseRouting();

            app.UseJwtApiAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BackupService>();
                endpoints.MapGrpcService<ServiceOpsService>();
                endpoints.MapGrpcService<ServiceService>();
                endpoints.MapGrpcService<UserService>();
            });
        }
    }
}
