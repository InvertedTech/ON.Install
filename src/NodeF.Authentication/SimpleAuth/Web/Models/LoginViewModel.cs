using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 4)]
        [Display(Name = "Login Name")]
        [RegularExpression(@"^[a-zA-Z0-9]+$")]
        public string LoginName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be less than {1}.")]
        [Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}
