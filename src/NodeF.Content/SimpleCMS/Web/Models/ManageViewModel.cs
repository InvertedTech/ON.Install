using NodeF.Authentication;
using NodeF.Fragments.Authentcation;
using NodeF.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Content.SimpleCMS.Web.Models
{
    public class ManageViewModel
    {
        public ManageViewModel() { }

        public ManageViewModel(IEnumerable<ContentRecord> records)
        {
            Records.AddRange(records);
        }

        public List<ContentRecord> Records { get; } = new List<ContentRecord>();
    }
}
