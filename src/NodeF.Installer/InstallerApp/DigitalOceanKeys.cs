using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp
{
    class DigitalOceanKeys
    {
        public DigitalOceanKey ssh_key { get; set; }
        public List<DigitalOceanKey> ssh_keys { get; set; }
    }
    class DigitalOceanKey
    {
        public int id { get; set; }
        public string public_key { get; set; }
        public string name { get; set; }
    }
}
