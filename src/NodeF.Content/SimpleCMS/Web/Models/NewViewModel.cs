using NodeF.Authentication;
using NodeF.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Content.SimpleCMS.Web.Models
{
    public class NewViewModel
    {
        public NewViewModel() { }

        public NewViewModel(NodeUser user)
        {
            Author = user.DisplayName;
        }

        [Required]
        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subtitle")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Subtitle { get; set; }

        [Required]
        [Display(Name = "Author")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Author { get; set; }

        [Display(Name = "Body")]
        public string Body { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
