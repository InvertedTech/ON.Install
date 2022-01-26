using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstallerApp.Deploy
{
    internal class Godaddy
    {
        internal static async Task ChangeDNS(DeployWindow window)
        {
            await window.AddLine("--- Changing DNS ---");

            using (WebClient wc = new())
            {
                wc.Headers.Add("accept", "application/json");
                wc.Headers.Add("Authorization", "sso-key " + window.MyModel.DNS.GodaddyApiKey + ":" + window.MyModel.DNS.GodaddyApiSecret);
                var json = await wc.DownloadStringTaskAsync($"https://api.godaddy.com/v1/domains/{window.MyModel.DNS.Name}/records/A/%40");
                var recs = JsonSerializer.Deserialize<List<GodaddyDNSRecord>>(json);

                if (recs.All(r => r.data == window.MyModel.Server.IP))
                {
                    await window.AddLine("No change needed.");
                    return;
                }

                recs.Clear();
                recs.Add(new()
                {
                    data = window.MyModel.Server.IP,
                    name = "@",
                    ttl = 600,
                    type = "A",
                });

                json = JsonSerializer.Serialize(recs);

                wc.Headers.Add("Content-Type", "application/json");
                await wc.UploadStringTaskAsync($"https://api.godaddy.com/v1/domains/{window.MyModel.DNS.Name}/records/A/%40", "PUT", json);

                await window.AddLine("Change complete");
            }
        }
    }
}
