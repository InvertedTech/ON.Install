using ON.Authentication;
using ON.Fragments.Authentcation;
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

        public HomeViewModel(IEnumerable<ContentRecord> records)
        {
            Records.AddRange(records);
        }

        public List<ContentRecord> Records { get; } = new List<ContentRecord>();
    }
}
