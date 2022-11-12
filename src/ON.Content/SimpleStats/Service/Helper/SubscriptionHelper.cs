using Microsoft.AspNetCore.Builder;
using ON.Authentication;
using ON.Content.SimpleStats.Service.Subscriptions;

namespace ON.Content.SimpleStats.Service.Helper
{
    public static class SubscriptionHelper
    {
        public static void LaunchSubscriptionServices(this IApplicationBuilder app)
        {
            app.ApplicationServices.GetService(typeof(ContentSubscription));
            app.ApplicationServices.GetService(typeof(UserSubscription));
        }
    }
}
