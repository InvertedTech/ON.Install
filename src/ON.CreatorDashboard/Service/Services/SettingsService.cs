using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Fragments.CreatorDashboard.Settings;
using ON.CreatorDashboard.Service.Models;
using ON.CreatorDashboard.Service.Interfaces;

namespace ON.CreatorDashboard.Service.Services
{
    public class SettingsService : SettingsManagerInterface.SettingsManagerInterfaceBase
    {
        private readonly ILogger<SettingsService> logger;
        private readonly IOptions<AppSettings> settings;


        public SettingsService(ILogger<SettingsService> logger, IOptions<AppSettings> settings)
        {
            this.logger = logger;
            this.settings = settings;
        }

        public override Task<SetModerationSettingsResponse> SetModerationSettings(SetModerationSettingsRequest req, ServerCallContext context)
        {
            return null;
        }

        public override Task<GetModerationSettingsResponse> GetModerationSettings(GetModerationSettingsRequest req, ServerCallContext context)
        {
            return null;
        }
    }
}
