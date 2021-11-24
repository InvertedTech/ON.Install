using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeF.Config
{
    public class ConfigManager
    {
        public static IConfigManager OpenDirectory(DirectoryInfo dir)
        {
            if (!dir.Exists)
                throw new Exception($"Directory \"{dir.FullName}\" doesn't exist.");

            return new DirectoryConfigManager(dir);
        }

        public static void OpenFile(FileInfo file)
        {
            //if (!file.Exists)
            //    throw new Exception($"File \"{file.FullName}\" doesn't exist.");

            //return new FileConfigManager(file);
        }
    }
}
