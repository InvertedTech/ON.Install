using Grpc.Core;
using Microsoft.Extensions.Logging;
using ON.Authorization.Paypal.Service.Models;
using ON.Fragments.Generic;
using ON.Settings;
using System.Threading.Tasks;
using static ON.Fragments.Generic.ServiceStatusResponse.Types;

namespace ON.Authorization.Paypal.Service
{
    public class ServiceOpsService : ServiceOpsInterface.ServiceOpsInterfaceBase
    {
        private readonly SettingsClient settingsClient;
        private readonly ILogger logger;

        public ServiceOpsService(ILogger<ServiceOpsService> logger, SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
            this.logger = logger;
        }

        public override async Task<ServiceStatusResponse> ServiceStatus(ServiceStatusRequest request, ServerCallContext context)
        {
            return new() { Status = await ServiceStatus(settingsClient) };
        }

        public static async Task<OnlineStatus> ServiceStatus(SettingsClient settingsClient)
        {
            if (!(await settingsClient.GetOwnerData()).Subscription.Paypal.Enabled)
                return ServiceStatusResponse.Types.OnlineStatus.Offline;

            if (!(await settingsClient.GetOwnerData()).Subscription.Paypal.IsValid)
                return ServiceStatusResponse.Types.OnlineStatus.Faulted;

            return ServiceStatusResponse.Types.OnlineStatus.Online;
        }
    }
}
