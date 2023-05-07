using Microsoft.Extensions.DependencyInjection;
using ON.Authentication;
using ON.Authorization.Payment.Fake.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Fake.Helper
{
    public static class StartupHelper
    {
        public static void AddFakeHelpers(this IServiceCollection services)
        {
            services.AddSingleton<ISubscriptionRecordProvider, FileSystemSubscriptionRecordProvider>();
        }
    }
}
