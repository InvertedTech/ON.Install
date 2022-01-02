using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON
{
    public static class SiteConfig
    {
        public static string WebsiteName = "Get ON";
        public static string WebsiteDesc = "Get ON with the ON Foundation";

        static SiteConfig()
        {
            var str = Environment.GetEnvironmentVariable("WEBSITE_NAME", EnvironmentVariableTarget.Process);
            if (str != null)
                WebsiteName = str;

            str = Environment.GetEnvironmentVariable("WEBSITE_DESC", EnvironmentVariableTarget.Process);
            if (str != null)
                WebsiteDesc = str;
        }
    }
}
