using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Deploy
{
    internal class DNSHelper
    {
        internal static async Task TestSite(DeployWindow window)
        {
            DateTime start = DateTime.Now;

            await window.AddLine("--- Testing Site ---");
            await Task.Delay(30);

            while ((DateTime.Now - start).TotalMinutes < 15)
            {
                try
                {
                    using (WebClient wc = new())
                    {
                        wc.Headers["Host"] = window.MyModel.DNS.Name;
                        var str = $"http://{window.MyModel.Server.IP}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            await window.AddLine("Site Verified!");
                            return;
                        }
                    }
                }
                catch { }
                await Task.Delay(30);
            }

            await window.AddLine("Site test unsuccessful...");
            throw new Exception();
        }


        internal static async Task TestDNS(DeployWindow window)
        {
            DateTime start = DateTime.Now;

            await window.AddLine("--- Testing DNS ---");
            await Task.Delay(30);

            while ((DateTime.Now - start).TotalMinutes < 15)
            {
                try
                {
                    using (WebClient wc = new())
                    {
                        wc.Headers["Host"] = window.MyModel.DNS.Name;
                        var str = $"http://{window.MyModel.DNS.Name}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            await window.AddLine("DNS Verified!");
                            return;
                        }
                    }
                }
                catch { }
                await Task.Delay(30);
            }

            await window.AddLine("DNS test unsuccessful...");
            throw new Exception();
        }
    }
}
