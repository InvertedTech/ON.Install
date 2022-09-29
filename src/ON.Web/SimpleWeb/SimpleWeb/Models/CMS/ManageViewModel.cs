using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.CMS
{
    public class ManageViewModel
    {
        public ManageViewModel() { }

        public ManageViewModel(IEnumerable<ContentListRecord> records)
        {
            Records.AddRange(records);
        }

        public List<ContentListRecord> Records { get; } = new List<ContentListRecord>();
    }
}
