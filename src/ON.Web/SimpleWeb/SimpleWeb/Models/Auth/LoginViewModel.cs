using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Auth
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "{0} length must be less than {1}.")]
        [Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
    }
}
