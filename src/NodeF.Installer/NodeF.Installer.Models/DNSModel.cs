using System;
using System.Collections.Generic;
using System.Linq;

namespace NodeF.Installer.Models
{
    public class DNSModel
    {
        public string GodaddyApiKey { get; set; } = "";
        public string GodaddyApiSecret { get; set; } = "";
        public string GodaddyCredsButtonLabel { get => string.IsNullOrEmpty(GodaddyApiKey) || string.IsNullOrEmpty(GodaddyApiSecret) ? "Enter Credentials" : "Re-Enter Credentials"; }

        public string Name { get; set; } = "";
    }
}
