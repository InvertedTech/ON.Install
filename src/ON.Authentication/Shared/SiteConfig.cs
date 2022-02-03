using Microsoft.IdentityModel.Tokens;
using ON.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ON
{
    public static class SiteConfig
    {
        public static string WebsiteName = "Get ON";
        public static string WebsiteDesc = "Get ON with the ON Foundation";
        public static SubscriptionTier[] SubscriptionTiers { get; private set; }

        static SiteConfig()
        {
            var str = Environment.GetEnvironmentVariable("WEBSITE_NAME", EnvironmentVariableTarget.Process);
            if (str != null)
                WebsiteName = Base64UrlEncoder.Decode(str);

            str = Environment.GetEnvironmentVariable("WEBSITE_DESC", EnvironmentVariableTarget.Process);
            if (str != null)
                WebsiteDesc = Base64UrlEncoder.Decode(str);

            str = Environment.GetEnvironmentVariable("SUBSCRIPTION_TIERS", EnvironmentVariableTarget.Process);
            if (str != null)
                SubscriptionTiers = JsonSerializer.Deserialize<SubscriptionTier[]>(Base64UrlEncoder.Decode(str));
        }
    }
}
