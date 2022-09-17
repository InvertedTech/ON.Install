using ON.SimpleWeb.Services.PE;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ON.SimpleWeb.Models.Subscription.PE
{
    public class CurrentViewModel
    {
        public CurrentViewModel()
        {
        }

        public CurrentViewModel(uint level, AccountService acctService, bool isCancelled)
        {
            Level = level;
            Name = acctService.Plans.OrderBy(t => t.Value).FirstOrDefault(t => t.Value >= level)?.Name ?? "";
            IsCancelled = isCancelled;
        }

        [Display(Name = "Subscription Amount")]
        [DataType(DataType.Currency)]
        public uint Level { get; set; }

        [Display(Name = "Subscription Name")]
        public string Name { get; set; }

        public bool IsCancelled { get; set; }
    }
}
