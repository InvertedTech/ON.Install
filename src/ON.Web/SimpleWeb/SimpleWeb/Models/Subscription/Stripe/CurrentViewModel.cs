using ON.SimpleWeb.Services.Stripe;
using System.ComponentModel.DataAnnotations;

namespace ON.SimpleWeb.Models.Subscription.Stripe
{
    public class CurrentViewModel
    {
        public CurrentViewModel()
        {
        }

        public CurrentViewModel(uint level, AccountService acctService, bool isCancelled)
        {
            Level = level;

            switch (Level )
            {
                case 100:
                    Name =  "Lord of the Manor";
                    break;
                case 50:
                    Name = "The Best!";
                    break;
                case 20:
                    Name = "Big Spender";
                    break;
                case 10:
                    Name = "Awesome Member";
                    break;
                case 5:
                    Name = "Member";
                    break;
                default:
                    Name = "No Name";
                    break;
            }
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
