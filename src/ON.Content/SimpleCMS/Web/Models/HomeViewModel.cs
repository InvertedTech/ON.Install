using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Web.Models
{
    public class HomeViewModel
    {
        public HomeViewModel() { }

        public HomeViewModel(IEnumerable<ContentRecord> records, ONUser user)
        {
            Records.AddRange(records);

            UserSubscriptionLevel = user?.SubscriptionLevel ?? 0;
        }

        public uint UserSubscriptionLevel { get; set; } = 0;

        public List<ContentRecord> Records { get; } = new List<ContentRecord>();
    }
}
