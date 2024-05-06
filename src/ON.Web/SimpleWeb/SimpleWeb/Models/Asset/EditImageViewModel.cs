using Microsoft.AspNetCore.Http;
using ON.Authentication;
using ON.Fragments.Authentication;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ON.SimpleWeb.Models.Asset
{
    public class EditImageViewModel
    {
        public EditImageViewModel() { }

        public EditImageViewModel(ImageAssetPublicRecord image)
        {
            Id = image.AssetID;
            Title = image.Data.Title;
            Caption = image.Data.Caption;
        }

        public string Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Title { get; set; }

        [Display(Name = "Caption")]
        [StringLength(100, ErrorMessage = "{0} length must be less than {1}.")]
        public string Caption { get; set; }

        [Display(Name = "Upload image to replace existing")]
        public IFormFile File { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
    }
}
