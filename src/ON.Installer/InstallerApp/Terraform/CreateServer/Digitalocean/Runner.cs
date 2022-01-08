using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.CreateServer.Digitalocean
{
    internal class Runner
    {
        internal static async Task CreateServeDigitalOcean(DeployWindow window)
        {
            await window.AddLine("--- Create Server ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/createServer/digitalocean");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            targetD.Create();
            await window.resHelper.SaveCreateDigitalocean(targetD);

            string prefix = "onf-" + window.MyModel.DNS.Name.Replace(".", "-");

            var ssh = window.keyHelper.DeriveEcSshKey();
            string keyId = GetDigitalOceanKey(window, prefix);
            if (keyId == null)
                keyId = await SetDigitalOceanKey(window, prefix, ssh.pubKey);

            var envVars = new Dictionary<string, string>();
            envVars["prefix"] = prefix;
            envVars["location"] = "nyc3";
            envVars["do_token"] = window.MyModel.Credentials.DigitalOceanKey;
            envVars["sshKeyId"] = keyId;

            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);

            var addyLine = (await File.ReadAllLinesAsync(targetD.FullName + "/terraform.tfstate")).FirstOrDefault(l => l.Contains("\"ipv4_address\""));
            var addy = addyLine.GetBetween(": \"", "\"");
            window.MyModel.Server.IP = addy;
            window.MyModel.Server.User = "root";
            window.needDockerInstalled = false;
        }

        private static async Task<string> SetDigitalOceanKey(DeployWindow window, string name, string pubKey)
        {
            try
            {
                using (WebClient wc = new())
                {
                    DigitalOceanKey key = new DigitalOceanKey()
                    {
                        name = name,
                        public_key = pubKey
                    };

                    var json = JsonSerializer.Serialize(key);


                    wc.Headers.Add("accept", "application/json");
                    wc.Headers.Add("Authorization", "Bearer " + window.MyModel.Credentials.DigitalOceanKey);
                    wc.Headers.Add("Content-Type", "application/json");
                    json = await wc.UploadStringTaskAsync("https://api.digitalocean.com/v2/account/keys", "POST", json);
                    var domains = JsonSerializer.Deserialize<DigitalOceanKeys>(json);

                    return domains.ssh_key.id.ToString();
                }
            }
            catch
            {
            }

            return null;
        }

        private static string GetDigitalOceanKey(DeployWindow window, string name)
        {
            try
            {
                using (WebClient wc = new())
                {
                    wc.Headers.Add("accept", "application/json");
                    wc.Headers.Add("Authorization", "Bearer " + window.MyModel.Credentials.DigitalOceanKey);
                    var json = wc.DownloadString("https://api.digitalocean.com/v2/account/keys");
                    var domains = JsonSerializer.Deserialize<DigitalOceanKeys>(json);

                    return domains.ssh_keys.FirstOrDefault(d => d.name == name)?.id.ToString();
                }
            }
            catch
            {
            }

            return null;
        }
    }
}
