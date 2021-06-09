using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NodeF.Authentication.SimpleAuth.Service.Data;
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
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseMiddleware<JwtValidatorMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ServiceOpsService>();
                endpoints.MapGrpcService<UserService>();
            });
        }
    }
}
