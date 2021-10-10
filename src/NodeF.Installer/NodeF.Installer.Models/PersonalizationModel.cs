using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace NodeF.Installer.Models
{
    public class PersonalizationModel
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        [JsonIgnore]
        public List<string> Keywords { get; set; } = new List<string>();
        public string KeywordsWithCommas
        {
            get
            {
                if (Keywords == null || Keywords.Count == 0)
                    return "";
                return Keywords.Where(s => !string.IsNullOrWhiteSpace(s)).Aggregate((current, next) => (current == null ? "" : current + ",") + next.Trim());
            }
            set
            {
                Keywords = value.Split(',').Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
            }
        }

        public byte[] Icon { get; set; }
    }
}
