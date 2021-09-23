using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeF.Config
{
    public class DirectoryConfigManager : IConfigManager
    {
        private DirectoryInfo dir;

        internal DirectoryConfigManager(DirectoryInfo dir)
        {
            this.dir = dir;
        }
    }
}
