using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ON.Crypto;
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ON.Settings
{
    public static class SettingsExtensions
    {
        public static void AddSettingsHelpers(this IServiceCollection services)
        {
            services.AddSingleton<CategoryHelper>();
            services.AddSingleton<ChannelHelper>();
            services.AddSingleton<ServiceNameHelper>();
            services.AddSingleton<SettingsClient>();
            services.AddSingleton<SubscriptionTierHelper>();
        }
    }
}
