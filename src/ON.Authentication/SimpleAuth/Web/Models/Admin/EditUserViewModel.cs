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

        public EditUserViewModel(UserNormalRecord user)
        {
            UserName = user.Public.Data.UserName;
            DisplayName = user.Public.Data.DisplayName;
            Email = user.Private.Data.Emails.FirstOrDefault();

            IsOwner = user.Private.Roles.Contains(ONUser.ROLE_OWNER);
            IsAdmin = user.Private.Roles.Contains(ONUser.ROLE_ADMIN);
            IsContentPublisher = user.Private.Roles.Contains(ONUser.ROLE_CONTENT_PUBLISHER);
            IsContentWriter = user.Private.Roles.Contains(ONUser.ROLE_CONTENT_WRITER);
            IsCommentModerator = user.Private.Roles.Contains(ONUser.ROLE_COMMENT_MODERATOR);
            IsCommentAppelateJudge = user.Private.Roles.Contains(ONUser.ROLE_COMMENT_APPELLATE_JUDGE);
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

        [Display(Name = "Owner")]
        public bool IsOwner { get; set; }

        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Content Publisher")]
        public bool IsContentPublisher { get; set; }

        [Display(Name = "Content Writer")]
        public bool IsContentWriter { get; set; }

        [Display(Name = "Comment Moderator")]
        public bool IsCommentModerator { get; set; }

        [Display(Name = "Comment Appelate Judge")]
        public bool IsCommentAppelateJudge { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
