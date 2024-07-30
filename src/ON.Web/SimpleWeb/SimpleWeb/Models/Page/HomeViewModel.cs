using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Page
{
    public class HomeViewModel
    {
        public HomeViewModel() { }

        public HomeViewModel(IEnumerable<ContentListRecord> records, ONUser user)
        {
            Records.AddRange(records);

            ShowLockStatus = !(user?.IsWriterOrHigher ?? false);
            UserSubscriptionLevel = user?.SubscriptionLevel ?? 0;
        }

        public bool ShowLockStatus { get; set; }

        public uint UserSubscriptionLevel { get; set; } = 0;

        public List<ContentListRecord> Records { get; } = new List<ContentListRecord>();
    }
}
