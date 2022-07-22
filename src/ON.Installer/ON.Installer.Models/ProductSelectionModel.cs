using System;
using System.Collections.Generic;
using System.Linq;

namespace ON.Installer.Models
{
    public class ProductSelectionModel
    {
        public HomepageProducts Homepage { get; set; } = HomepageProducts.CMS;

        public enum HomepageProducts
        {
            CMS = 0,
            Business = 1,
        }
    }
}
