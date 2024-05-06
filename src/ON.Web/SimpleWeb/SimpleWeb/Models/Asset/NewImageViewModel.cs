using Microsoft.AspNetCore.Http;
using ON.Authentication;
using ON.Fragments.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Asset
{
    public class NewImageViewModel
    {
        public NewImageViewModel() { }

        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Title { get; set; }

        [Display(Name = "Caption")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Caption { get; set; }

        [Display(Name = "Upload image file")]
        [Required]
        public IFormFile File { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
