using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ON.Authentication;
using ON.Notification.SimpleNotification.Service.Data;
using ON.Notification.SimpleNotification.Service.Helpers;
using ON.Notification.SimpleNotification.Service.Models;
using ON.Notification.SimpleNotification.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Notification.SimpleNotification.Service
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
            services.AddControllersWithViews()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = new NeutralNamingPolicy();
                    });

            //services.AddGrpc();
            services.AddGrpcHttpApi();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("notification", new OpenApiInfo { Title = "SimpleNotification API" });
            });
            services.AddGrpcSwagger();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.AddSingleton<INotificationUserDataProvider, FileSystemNotificationUserDataProvider>();
            services.AddSingleton<IUserNotificationDataProvider, FileSystemUserNotificationDataProvider>();

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
                c.SwaggerEndpoint("/api/notification/swagger.json", "SimpleNotification API");
                c.RoutePrefix = "api/notification";
            });

            if (env.IsDevelopment())
                Program.IsDevelopment = true;

            app.UseStaticFiles();

            app.UseRouting();

            app.UseJwtApiAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<UserService>();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
