using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth
{
    public class ChangePasswordViewModel
    {
        public ChangePasswordViewModel() { }

        [Required, DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string OldPassword { get; set; }

        [Required, DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Minimum eight characters, at least one letter and one number.")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password), Compare(nameof(NewPassword))]
        [Display(Name = "Confirm New Password")]
        public string ConfirmNewPassword { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
