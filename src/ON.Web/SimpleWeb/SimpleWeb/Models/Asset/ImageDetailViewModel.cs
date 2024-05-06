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
    public class ImageDetailViewModel
    {
        public ImageDetailViewModel() { }
        public ImageDetailViewModel(ImageAssetPublicRecord image)
        {
            Id = image.AssetID;
            Title = image.Data.Title;
            Caption = image.Data.Caption;
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
    }
}
