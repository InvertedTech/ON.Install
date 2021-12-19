using InstallerApp.Security;
using ON.Installer.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InstallerApp
{
    /// <summary>
    /// Interaction logic for DeployWindow.xaml
    /// </summary>
    public partial class DeployWindow : Window
    {
        MainModel MyModel;
        DirectoryInfo DeployRootD;
        KeyHelper keyHelper;

        public DeployWindow()
        {
            InitializeComponent();
        }

        internal async Task StartDeploying()
        {
            MyModel = MainWindow.MainModel;
            keyHelper = new KeyHelper(MyModel.Credentials.MasterKey);
            DeployRootD = new DirectoryInfo($"c:/tmp/onf/terraform/{MyModel.DNS.Name}");

            var origD = new DirectoryInfo("../../../../../terraform");

            if (!DeployRootD.Exists)
            {
                DeployRootD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(DeployRootD + "/" + f.Name);
            }

            Task createServer = CreateServer();
            await WaitOnTask(createServer, txtCreateServer);
            if (!createServer.IsCompletedSuccessfully)
                return;

            Task installDocker = InstallDocker();
            await WaitOnTask(installDocker, txtDocker);
            if (!installDocker.IsCompletedSuccessfully)
                return;

            Task deploySite = DeploySite();
            await WaitOnTask(deploySite, txtDeploySite);
            if (!deploySite.IsCompletedSuccessfully)
                return;

            Task testSite = TestSite();
            await WaitOnTask(testSite, txtTestSite);
            if (!testSite.IsCompletedSuccessfully)
                return;

            Task changeDns = ChangeDNS();
            await WaitOnTask(changeDns, txtChangeDNS);
            if (!changeDns.IsCompletedSuccessfully)
                return;

            Task testDns = TestDNS();
            await WaitOnTask(testDns, txtTestDNS);
            if (!testDns.IsCompletedSuccessfully)
                return;

        }

        internal async Task CreateServer()
        {
            //await CreateServerAzure();
            await CreateServeDigitalOcean();
        }

        internal async Task CreateServerAzure()
        {
            AddLine("--- Create Server ---");

            var origD = new DirectoryInfo("../../../../../terraform/createServer/azure");
            var targetD = new DirectoryInfo($"{DeployRootD.FullName}/createServer/azure");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            var ssh = SshHelper.CreateRSAKey("temp@onf");
            var envVars = new Dictionary<string, string>();
            envVars["prefix"] = "onf-" + MyModel.DNS.Name.Replace(".", "-");
            envVars["location"] = "centralus";
            envVars["username"] = "onfadmin";
            envVars["sshPub"] = ssh.pubKey;


            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init", envVars);
            }

            await RunTerraform(targetD, "apply -auto-approve", envVars);
            await RunTerraform(targetD, "refresh", envVars);

            var addyLine = (await File.ReadAllLinesAsync(targetD.FullName + "/terraform.tfstate")).FirstOrDefault(l => l.Contains("\"public_ip_address\""));
            var addy = addyLine.GetBetween(": \"", "\"");
            MyModel.Server.IP = addy;
            MyModel.Server.User = "onfadmin";

            await ChangeSshKey(ssh.privKey);
        }

        internal async Task ChangeSshKey(string tempSshPriv)
        {
            AddLine("--- Changing SSH Key ---");

            var origD = new DirectoryInfo("../../../../../terraform/changeSsh");
            var targetD = new DirectoryInfo($"{DeployRootD.FullName}/changeSsh");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            var ssh = keyHelper.DeriveEcSshKey();

            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = MyModel.Server.IP;
            envVars["username"] = MyModel.Server.User;
            envVars["tempSshPriv"] = tempSshPriv;
            envVars["sshPub"] = ssh.pubKey;

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init", envVars);
            }

            await RunTerraform(targetD, "apply -auto-approve", envVars);
        }

        internal async Task CreateServeDigitalOcean()
        {
            AddLine("--- Create Server ---");

            var origD = new DirectoryInfo("../../../../../terraform/createServer/digitalocean");
            var targetD = new DirectoryInfo($"{DeployRootD.FullName}/createServer/digitalocean");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            targetD.Create();
            foreach (var f in origD.GetFiles())
                f.CopyTo(targetD + "/" + f.Name, true);

            string prefix = "onf-" + MyModel.DNS.Name.Replace(".", "-");

            var ssh = keyHelper.DeriveEcSshKey();
            string keyId = GetDigitalOceanKey(prefix);
            if (keyId == null)
                keyId = await SetDigitalOceanKey(prefix, ssh.pubKey);

            var envVars = new Dictionary<string, string>();
            envVars["prefix"] = prefix;
            envVars["location"] = "nyc3";
            envVars["do_token"] = MyModel.Credentials.DigitalOceanKey;
            envVars["sshKeyId"] = keyId;

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init", envVars);
            }

            await RunTerraform(targetD, "apply -auto-approve", envVars);

            var addyLine = (await File.ReadAllLinesAsync(targetD.FullName + "/terraform.tfstate")).FirstOrDefault(l => l.Contains("\"ipv4_address\""));
            var addy = addyLine.GetBetween(": \"", "\"");
            MyModel.Server.IP = addy;
            MyModel.Server.User = "root";
        }

        private async Task<string> SetDigitalOceanKey(string name, string pubKey)
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
                    wc.Headers.Add("Authorization", "Bearer " + MyModel.Credentials.DigitalOceanKey);
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

        private string GetDigitalOceanKey(string name)
        {
            try
            {
                using (WebClient wc = new())
                {
                    wc.Headers.Add("accept", "application/json");
                    wc.Headers.Add("Authorization", "Bearer " + MyModel.Credentials.DigitalOceanKey);
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

        internal async Task InstallDocker()
        {
            AddLine("--- Install Docker ---");

            var origD = new DirectoryInfo("../../../../../terraform/installDocker");
            var targetD = new DirectoryInfo($"{DeployRootD.FullName}/installDocker");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            var ssh = keyHelper.DeriveEcSshKey();
            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = MyModel.Server.IP;
            envVars["username"] = MyModel.Server.User;
            envVars["sshPriv"] = ssh.privKey;

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init", envVars);
            }

            await RunTerraform(targetD, "apply -auto-approve", envVars);
        }

        internal async Task DeploySite()
        {
            AddLine("--- Deploy Site ---");

            var origD = new DirectoryInfo("../../../../../terraform/deploySite");
            var targetD = new DirectoryInfo($"{DeployRootD.FullName}/deploySite");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");
            var envF = new FileInfo(targetD.FullName + "/.env");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            var ssh = keyHelper.DeriveEcSshKey();
            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = MyModel.Server.IP;
            envVars["username"] = MyModel.Server.User;
            envVars["sshPriv"] = ssh.privKey;

            await WriteEnvFile(envF);

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init", envVars);
            }

            await RunTerraform(targetD, "apply -auto-approve", envVars);
        }

        internal async Task TestSite()
        {
            DateTime start = DateTime.Now;

            AddLine("--- Testing Site ---");
            await Task.Delay(30);

            while ((DateTime.Now - start).TotalMinutes < 15)
            {
                try
                {
                    using (WebClient wc = new())
                    {
                        wc.Headers["Host"] = MyModel.DNS.Name;
                        var str = $"http://{MyModel.Server.IP}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            AddLine("Site Verified!");
                            return;
                        }
                    }
                }
                catch { }
                await Task.Delay(30);
            }

            AddLine("Site test unsuccessful...");
            throw new Exception();
        }

        internal async Task ChangeDNS()
        {
            AddLine("--- Changing DNS ---");

            using (WebClient wc = new())
            {
                wc.Headers.Add("accept", "application/json");
                wc.Headers.Add("Authorization", "sso-key " + MyModel.DNS.GodaddyApiKey + ":" + MyModel.DNS.GodaddyApiSecret);
                var json = await wc.DownloadStringTaskAsync($"https://api.godaddy.com/v1/domains/{MyModel.DNS.Name}/records/A/%40");
                var recs = JsonSerializer.Deserialize<List<GodaddyDNSRecord>>(json);

                if (recs.All(r => r.data == MyModel.Server.IP))
                {
                    AddLine("No change needed.");
                    return;
                }

                recs.Clear();
                recs.Add(new()
                {
                    data = MyModel.Server.IP,
                    name = "@",
                    ttl = 600,
                    type = "A",
                });

                json = JsonSerializer.Serialize(recs);

                wc.Headers.Add("Content-Type", "application/json");
                await wc.UploadStringTaskAsync($"https://api.godaddy.com/v1/domains/{MyModel.DNS.Name}/records/A/%40", "PUT", json);

                AddLine("Change complete");
            }
        }

        internal async Task TestDNS()
        {
            DateTime start = DateTime.Now;

            AddLine("--- Testing DNS ---");
            await Task.Delay(30);

            while ((DateTime.Now - start).TotalMinutes < 15)
            {
                try
                {
                    using (WebClient wc = new())
                    {
                        wc.Headers["Host"] = MyModel.DNS.Name;
                        var str = $"http://{MyModel.DNS.Name}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            AddLine("DNS Verified!");
                            return;
                        }
                    }
                }
                catch { }
                await Task.Delay(30);
            }

            AddLine("DNS test unsuccessful...");
            throw new Exception();
        }

        private async Task RunTerraform(DirectoryInfo d, string extra, Dictionary<string,string> envVars = null)
        {
            var pInfo = new ProcessStartInfo("terraform", extra);
            pInfo.WorkingDirectory = d.FullName;
            pInfo.CreateNoWindow = true;
            pInfo.UseShellExecute = false;
            pInfo.RedirectStandardOutput = true;
            pInfo.RedirectStandardError = true;

            if (envVars != null)
            {
                foreach (var v in envVars)
                    pInfo.Environment["TF_VAR_" + v.Key] = v.Value;
            }

            using (var p = new Process())
            {
                p.StartInfo = pInfo;
                p.Start();

                p.OutputDataReceived += P_OutputDataReceived;
                p.ErrorDataReceived += P_OutputDataReceived;
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                await p.WaitForExitAsync();
                if (p.ExitCode != 0)
                    throw new Exception();
            }
        }

        List<string> lines = new();
        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            AddLine(e.Data);
        }

        private void AddLine(string inStr)
        {
            if (inStr == null)
                return;

            var str = Regex.Replace(inStr, @"\e\[(\d+;)*(\d+)?[ABCDHJKfmsu]", "");
            lines.AddRange(str.Replace("\r", "").Split('\n').Select(l => l.Trim()));
            lines = lines.Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            while (lines.Count > 10)
                lines.RemoveAt(0);

            this.Dispatcher.Invoke(() =>
            {
                txtOutput.Text = string.Join('\n', lines);
            });
        }

        private async Task WriteEnvFile(FileInfo f)
        {
            var jwtKey = keyHelper.DeriveEcJwtKey();

            List<string> l = new();
            l.Add("DNSNAME=" + MyModel.DNS.Name);
            l.Add("JWTPRIV="+jwtKey.privKey);
            l.Add("JWTPUB="+jwtKey.pubKey);

            await File.WriteAllLinesAsync(f.FullName, l);
        }

        private async Task WaitOnTask(Task t, TextBlock txt)
        {
            DateTime start = DateTime.Now;

            while (!t.IsCompleted)
            {
                txt.Text = $"Running... {(int)(DateTime.Now - start).TotalSeconds}s";
                await Task.Delay(1000);
            }

            if (t.IsCompletedSuccessfully)
                txt.Text = $"Done... {(int)(DateTime.Now - start).TotalSeconds}s";
            else
                txt.Text = $"Error!... {(int)(DateTime.Now - start).TotalSeconds}s";
        }
    }
}
