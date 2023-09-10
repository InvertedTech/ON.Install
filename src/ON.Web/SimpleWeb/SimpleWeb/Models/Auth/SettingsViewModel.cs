using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth
{
    public class SettingsViewModel
    {
        public SettingsViewModel() { }

        public SettingsViewModel(UserNormalRecord user)
        {
            UserName = user.Public.Data.UserName;
            DisplayName = user.Public.Data.DisplayName;
            Email = user.Private.Data.Emails.FirstOrDefault();
        }

        [Display(Name = "User Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Display Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        public string DisplayName { get; set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }

        public List<TOTPDeviceLimited> TotpDevices { get; internal set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
