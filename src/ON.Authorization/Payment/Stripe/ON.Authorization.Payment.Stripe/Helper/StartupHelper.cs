using Microsoft.Extensions.DependencyInjection;
using ON.Authentication;
using ON.Authorization.Payment.Stripe.Clients;
using ON.Authorization.Payment.Stripe.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Helper
{
    public static class StartupHelper
    {
        public static void AddStripeHelpers(this IServiceCollection services)
        {
            services.AddSingleton<StripeClient>();
            services.AddSingleton<DataMergeService>();
            services.AddSingleton<IPaymentRecordProvider, FileSystemPaymentRecordProvider>();
            services.AddSingleton<IProductRecordProvider, FileSystemProductRecordProvider>();
            services.AddSingleton<ISubscriptionRecordProvider, FileSystemSubscriptionRecordProvider>();
        }
    }
}
