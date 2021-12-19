using Microsoft.Extensions.Logging;
using ON.Fragments.Authentcation;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace ON.Authentication.SimpleAuth.Web.Helper
{
    public class OfflineHelper
    {
        private readonly ILogger<OfflineHelper> logger;
        private readonly ServiceNameHelper nameHelper;

        private DateTime nextCheck = DateTime.MinValue;
        private Timer timer;

        public OfflineHelper(ServiceNameHelper nameHelper, ILogger<OfflineHelper> logger)
        {
            this.nameHelper = nameHelper;
            this.logger = logger;

            timer = new Timer(10000);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            Timer_Elapsed(null, null);
        }

        public bool IsOffline { get; private set; } = true;

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                var client = new ServiceOpsInterface.ServiceOpsInterfaceClient(nameHelper.UserServiceChannel);
                var reply = client.ServiceStatus(new ServiceStatusRequest(), null, DateTime.UtcNow.AddSeconds(2));
                if (reply == null)
                    return;

                if (reply.Status == ServiceStatusResponse.Types.OnlineStatus.Online)
                    IsOffline = false;
                else
                    IsOffline = true;
            }
            catch
            {
            }
        }
    }
}
