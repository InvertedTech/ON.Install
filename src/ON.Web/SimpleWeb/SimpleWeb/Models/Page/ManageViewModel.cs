using ON.Fragments.Page;
using System.Collections.Generic;

namespace ON.SimpleWeb.Models.Page
{
    public class ManageViewModel
    {
        public ManageViewModel() { }

        public ManageViewModel(IEnumerable<PageListRecord> records)
        {
            Records.AddRange(records);
        }

        public List<PageListRecord> Records { get; } = new List<PageListRecord>();
    }
}
