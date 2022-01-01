using Microsoft.AspNetCore.Mvc.Rendering;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Web.Models.Admin
{
    public class EditUserViewModel
    {
        public EditUserViewModel() { }

        public EditUserViewModel(UserRecord user)
        {
            UserName = user.Public.UserName;
            DisplayName = user.Public.DisplayName;
            Email = user.Private.Emails.FirstOrDefault();

            IsAdmin = user.Public.Roles.Contains(ONUser.ROLE_ADMIN);
            IsPublisher = user.Public.Roles.Contains(ONUser.ROLE_PUBLISHER);
            IsWriter = user.Public.Roles.Contains(ONUser.ROLE_WRITER);
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

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Publisher")]
        public bool IsPublisher { get; set; }

        [Display(Name = "Writer")]
        public bool IsWriter { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
