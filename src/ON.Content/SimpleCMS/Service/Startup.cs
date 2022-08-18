using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ON.Authentication;
using ON.Content.SimpleCMS.Service.Data;
using ON.Content.SimpleCMS.Service.Models;
using ON.Content.SimpleCMS.Service.Services;

namespace ON.Content.SimpleCMS.Service
{
    public class Startup
    {
        private static byte[] PONG_RESPONSE = { (byte)'p', (byte)'o', (byte)'n', (byte)'g' };

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc(options =>
            {
                // options.EnableDetailedErrors = true;
                options.MaxReceiveMessageSize = null;
                options.MaxSendMessageSize = null;
            });

            //services.AddGrpcHttpApi();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("cms", new OpenApiInfo { Title = "SimpleCMS API" });
            //});
            //services.AddGrpcSwagger();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<IAssetDataProvider, FileSystemAssetDataProvider>();
            services.AddSingleton<IContentDataProvider, FileSystemContentDataProvider>();

            services.AddJwtAuthentication();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Map("/ping", (app1) => app1.Run(async context => {
                await context.Response.BodyWriter.WriteAsync(PONG_RESPONSE);
            }));

            //app.UseSwagger(c =>
            //{
            //    c.RouteTemplate = "api/{documentName}/swagger.json";
            //});
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/api/cms/swagger.json", "SimpleCMS API");
            //    c.RoutePrefix = "api/cms";
            //});

            app.UseRouting();

            app.UseJwtApiAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<AssetService>();
                endpoints.MapGrpcService<BackupService>();
                endpoints.MapGrpcService<ContentService>();
                endpoints.MapGrpcService<ServiceOpsService>();
            });
        }
    }
}
