using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authentication.SimpleAuth.Web.Models
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [Required]
        public string LoginName { get; set; }
        [Required, DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(ConfirmPassword))]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public string ErrorMessage { get; set; }
    }
}
