using ON.Fragments.Authentication;
using ON.Settings;
using System.Collections.Generic;
using System.Linq;

namespace ON.Content.SimpleComment.Service.Helper
{
    public class UserDataHelper
    {
        private readonly ServiceNameHelper nameHelper;
        private Dictionary<string, UserIdRecord> lookup = new();
        private System.Timers.Timer timer;

        public UserDataHelper(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;
            timer = new System.Timers.Timer()
            {
                Interval = 1000 * 60 * 60,
                AutoReset = true,
                Enabled = true,
            };

            Load();

            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Load();
        }

        private void Load()
        {
            var client = new UserInterface.UserInterfaceClient(nameHelper.UserServiceChannel);
            var reply = client.GetUserIdList(new());
            lookup = reply.Records.ToDictionary(r => r.UserID.ToLower(), r => r);
        }

        public UserIdRecord GetRecord(string userId)
        {
            lookup.TryGetValue(userId.ToLower(), out var record);
            return record ?? new() { UserID = userId, DisplayName = "Unknown", UserName = "Unknown" };
        }
    }
}
