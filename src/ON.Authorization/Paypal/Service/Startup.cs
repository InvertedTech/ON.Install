using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ON.Authentication;
using ON.Authorization.Paypal.Service.Clients;
using ON.Authorization.Paypal.Service.Data;
using ON.Authorization.Paypal.Service.Models;
using ON.Settings;

namespace ON.Authorization.Paypal.Service
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
            services.AddGrpcHttpApi();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("paypal", new OpenApiInfo { Title = "Paypal API" });
            });
            services.AddGrpcSwagger();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<SettingsClientSettings>(Configuration.GetSection("SettingsClientSettings"));

            services.AddSingleton<PaypalClient>();
            services.AddSingleton<ISubscriptionRecordProvider, FileSystemSubscriptionRecordProvider>();
            services.AddSingleton<IPlanRecordProvider, FileSystemPlanRecordProvider>();

            services.AddJwtAuthentication();
            services.AddSettingsHelpers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                c.SwaggerEndpoint("/api/paypal/swagger.json", "Paypal API");
                c.RoutePrefix = "api/paypal";
            });

            if (env.IsDevelopment())
                Program.IsDevelopment = true;

            app.UseRouting();

            app.UseJwtAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClaimsService>();
                endpoints.MapGrpcService<PaymentsService>();
                endpoints.MapGrpcService<ServiceOpsService>();
            });
        }
    }
}
