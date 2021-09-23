using System;
using System.Collections.Generic;

namespace NodeF.Installer.Models
{
    public class PersonalizationModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Keywords { get; set; }
        public byte[] Icon { get; set; }
    }
}
