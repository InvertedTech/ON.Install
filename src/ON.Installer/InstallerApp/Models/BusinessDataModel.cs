using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Models
{
    internal class BusinessDataModel
    {
        public string BusinessName { get; set; }
        public string BusinessTagLine { get; set; }
        public string Phone { get; set; }
        public string LogoImg { get; set; } = "";
        public string BannerImg { get; set; } = "";
        public string WhatWeDo { get; set; }
        public string AboutUs { get; set; }
        public AddressModel Address { get; set; } = new();
        public List<string> Carousel { get; set; } = new();
        public List<HoursModel> Hours { get; set; } = new();
        public ThemeModel Theme { get; set; } = new();

        internal class AddressModel
        {
            public string Line1 { get; set; } = "556 That Way";
            public string Line2 { get; set; } = "";
            public string Locality { get; set; } = "Somewhere";
            public string Region { get; set; } = "TX";
            public string PostalCode { get; set; } = "77777";
            public string Country { get; set; } = "US";
        }

        internal class HoursModel
        {
            public string Day { get; set; }
            public string Start { get; set; }
            public string End { get; set; }
        }

        internal class ThemeModel
        {
            public ColorModel Color { get; set; } = new();

            internal class ColorModel
            {
                public string Background { get; set; } = "#F0F0F0";
                public string Text { get; set; } = "#0F0F0F";
            }
        }
    }
}
