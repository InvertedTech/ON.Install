using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ON.Authentication;
using ON.Authorization.Payment.Fake.Helper;
using ON.Authorization.Payment.Fake.Service;
using ON.Authorization.Payment.Paypal.Helper;
using FakeM = ON.Authorization.Payment.Fake.Models;
using PaypalM = ON.Authorization.Payment.Paypal.Models;
using ON.Authorization.Payment.Paypal.Services;
using ON.Settings;

namespace ON.Authorization.Payment.Service
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
                c.SwaggerDoc("payment", new OpenApiInfo { Title = "Payment API" });
            });
            services.AddGrpcSwagger();

            services.Configure<FakeM.AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<PaypalM.AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddFakeHelpers();
            services.AddPaypalHelpers();

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
                c.SwaggerEndpoint("/api/payment/swagger.json", "Payment API");
                c.RoutePrefix = "api/payment";
            });

            if (env.IsDevelopment())
                Program.IsDevelopment = true;

            app.UseRouting();

            app.UseJwtAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<ClaimsService>();
                endpoints.MapGrpcService<PaymentService>();
                endpoints.MapGrpcService<FakeService>();
                endpoints.MapGrpcService<PaypalService>();
                endpoints.MapGrpcService<ServiceOpsService>();
            });
        }
    }
}
