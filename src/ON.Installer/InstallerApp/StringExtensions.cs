using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp
{
    static class StringExtensions
    {
        public static string GetBetween(this string inStr, string a, string b)
        {
            var i = inStr.IndexOf(a);
            if (i == -1)
                return null;

            var mid = inStr.Substring(i + a.Length);

            i = mid.IndexOf(b);
            if (i == -1)
                return null;

            return mid.Substring(0, i);
        }
    }
}
