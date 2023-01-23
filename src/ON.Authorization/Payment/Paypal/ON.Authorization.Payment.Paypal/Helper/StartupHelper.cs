using Microsoft.Extensions.DependencyInjection;
using ON.Authentication;
using ON.Authorization.Payment.Paypal.Clients;
using ON.Authorization.Payment.Paypal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Helper
{
    public static class StartupHelper
    {
        public static void AddPaypalHelpers(this IServiceCollection services)
        {
            services.AddSingleton<PaypalClient>();
            services.AddSingleton<DataMergeService>();
            services.AddSingleton<ISubscriptionRecordProvider, FileSystemSubscriptionRecordProvider>();
            services.AddSingleton<IPaymentRecordProvider, FileSystemPaymentRecordProvider>();
        }
    }
}
