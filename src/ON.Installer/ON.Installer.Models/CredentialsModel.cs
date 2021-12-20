using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Installer.Models
{
    public class CredentialsModel
    {
        public string MasterKey { get; set; }
        public string DigitalOceanKey { get; set; } = "";
    }
}
