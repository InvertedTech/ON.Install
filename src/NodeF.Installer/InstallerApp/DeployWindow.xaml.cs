using NodeF.Installer.Models;
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

        public DeployWindow()
        {
            InitializeComponent();
        }

        internal async Task StartDeploying()
        {
            MyModel = MainWindow.MainModel;

            var origD = new DirectoryInfo("../../../../../terraform");
            var targetD = new DirectoryInfo($"terraform/{MyModel.DNS.Name}");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
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
            AddLine("--- Create Server ---");

            var origD = new DirectoryInfo("../../../../../terraform/createServer/azure");
            var targetD = new DirectoryInfo($"terraform/{MyModel.DNS.Name}/createServer/azure");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            await WriteAzureVarFile(varF);

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init");
            }

            await RunTerraform(targetD, "apply -auto-approve");
            await RunTerraform(targetD, "refresh");

            var addyLine = (await File.ReadAllLinesAsync(targetD.FullName + "/terraform.tfstate")).FirstOrDefault(l => l.Contains("\"public_ip_address\""));
            var addy = addyLine.GetBetween(": \"", "\"");
            MyModel.Server.IP = addy;
        }

        internal async Task InstallDocker()
        {
            AddLine("--- Install Docker ---");

            var origD = new DirectoryInfo("../../../../../terraform/installDocker");
            var targetD = new DirectoryInfo($"terraform/{MyModel.DNS.Name}/installDocker");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            await WriteSSHVarFile(varF);

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init");
            }

            await RunTerraform(targetD, "apply -auto-approve");
        }

        internal async Task DeploySite()
        {
            AddLine("--- Deploy Site ---");

            var origD = new DirectoryInfo("../../../../../terraform/deploySite");
            var targetD = new DirectoryInfo($"terraform/{MyModel.DNS.Name}/deploySite");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");
            var envF = new FileInfo(targetD.FullName + "/.env");

            if (!targetD.Exists)
            {
                targetD.Create();
                foreach (var f in origD.GetFiles())
                    f.CopyTo(targetD + "/" + f.Name);
            }

            await WriteSSHVarFile(varF);
            await WriteEnvFile(envF);

            if (!terraD.Exists)
            {
                await RunTerraform(targetD, "init");
            }

            await RunTerraform(targetD, "apply -auto-approve");
        }

        internal async Task TestSite()
        {
            DateTime start = DateTime.Now;

            AddLine("--- Testing Site ---");
            await Task.Delay(30);

            using (WebClient wc = new())
            {
                wc.Headers["Host"] = MyModel.DNS.Name;
                while ((DateTime.Now - start).TotalMinutes < 15)
                {
                    try
                    {
                        var str = $"http://{MyModel.Server.IP}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            AddLine("Site Verified!");
                            return;
                        }
                    }
                    catch { }
                    await Task.Delay(30);
                }
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

            using (WebClient wc = new())
            {
                while ((DateTime.Now - start).TotalMinutes < 15)
                {
                    try
                    {
                        var str = $"http://{MyModel.DNS.Name}/ping";
                        var res = await wc.DownloadStringTaskAsync(str);
                        if (res == "pong")
                        {
                            AddLine("DNS Verified!");
                            return;
                        }
                    }
                    catch { }
                    await Task.Delay(30);
                }
            }

            AddLine("DNS test unsuccessful...");
            throw new Exception();
        }

        private async Task RunTerraform(DirectoryInfo d, string extra)
        {
            var pInfo = new ProcessStartInfo("terraform", extra);
            pInfo.WorkingDirectory = d.FullName;
            pInfo.CreateNoWindow = true;
            pInfo.UseShellExecute = false;
            pInfo.RedirectStandardOutput = true;
            pInfo.RedirectStandardError = true;

            var p = new Process();
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
            List<string> l = new();
            l.Add("DNSNAME=" + MyModel.DNS.Name);
            l.Add("JWTPRIV=eyJBZGRpdGlvbmFsRGF0YSI6e30sIkFsZyI6IkVTMjU2IiwiQ3J2IjoiUC0yNTYiLCJEIjoiT29QN3dhcUdtLU1fYU43N1dGSlZlXzc4Y2loMUZEX09hVmp5eHp6Q19SbyIsIkRQIjpudWxsLCJEUSI6bnVsbCwiRSI6bnVsbCwiSyI6bnVsbCwiS2V5SWQiOiJmNjBiMjNkNy1hN2JjLTQyY2MtYTRiNC1lN2JmMjQ4NmJjODkiLCJLZXlPcHMiOltdLCJLaWQiOiJmNjBiMjNkNy1hN2JjLTQyY2MtYTRiNC1lN2JmMjQ4NmJjODkiLCJLdHkiOiJFQyIsIk4iOm51bGwsIk90aCI6bnVsbCwiUCI6bnVsbCwiUSI6bnVsbCwiUUkiOm51bGwsIlVzZSI6InNpZyIsIlgiOiJUM0JDOVBSU2RqYUhwRXhVcXpnVGkxa3lfam8wb1hIcy1tU2g3RGxFVkUwIiwiWDVjIjpbXSwiWDV0IjpudWxsLCJYNXRTMjU2IjpudWxsLCJYNXUiOm51bGwsIlkiOiIyOGY0S0tLSHJnd18zZnhKUmxfVzR4TGRybkVRdU9BY19nTDI3S01zQ1I4IiwiS2V5U2l6ZSI6MjU2LCJIYXNQcml2YXRlS2V5Ijp0cnVlLCJDcnlwdG9Qcm92aWRlckZhY3RvcnkiOnsiQ3J5cHRvUHJvdmlkZXJDYWNoZSI6e30sIkN1c3RvbUNyeXB0b1Byb3ZpZGVyIjpudWxsLCJDYWNoZVNpZ25hdHVyZVByb3ZpZGVycyI6dHJ1ZX19");
            l.Add("JWTPUB=eyJBZGRpdGlvbmFsRGF0YSI6e30sIkFsZyI6IkVTMjU2IiwiQ3J2IjoiUC0yNTYiLCJEIjpudWxsLCJEUCI6bnVsbCwiRFEiOm51bGwsIkUiOm51bGwsIksiOm51bGwsIktleUlkIjoiZjYwYjIzZDctYTdiYy00MmNjLWE0YjQtZTdiZjI0ODZiYzg5IiwiS2V5T3BzIjpbXSwiS2lkIjoiZjYwYjIzZDctYTdiYy00MmNjLWE0YjQtZTdiZjI0ODZiYzg5IiwiS3R5IjoiRUMiLCJOIjpudWxsLCJPdGgiOm51bGwsIlAiOm51bGwsIlEiOm51bGwsIlFJIjpudWxsLCJVc2UiOiJzaWciLCJYIjoiVDNCQzlQUlNkamFIcEV4VXF6Z1RpMWt5X2pvMG9YSHMtbVNoN0RsRVZFMCIsIlg1YyI6W10sIlg1dCI6bnVsbCwiWDV0UzI1NiI6bnVsbCwiWDV1IjpudWxsLCJZIjoiMjhmNEtLS0hyZ3dfM2Z4SlJsX1c0eExkcm5FUXVPQWNfZ0wyN0tNc0NSOCIsIktleVNpemUiOjI1NiwiSGFzUHJpdmF0ZUtleSI6ZmFsc2UsIkNyeXB0b1Byb3ZpZGVyRmFjdG9yeSI6eyJDcnlwdG9Qcm92aWRlckNhY2hlIjp7fSwiQ3VzdG9tQ3J5cHRvUHJvdmlkZXIiOm51bGwsIkNhY2hlU2lnbmF0dXJlUHJvdmlkZXJzIjp0cnVlfX0");

            await File.WriteAllLinesAsync(f.FullName, l);
        }

        private async Task WriteAzureVarFile(FileInfo f)
        {
            List<string> l = new();
            l.Add("variable \"prefix\" { default = \"onf-" + MyModel.DNS.Name.Replace(".", "-") + "\" }");
            l.Add("variable \"location\" { default = \"centralus\" }");
            l.Add("variable \"username\" { default = \"onfadmin\" }");

            await File.WriteAllLinesAsync(f.FullName, l);
        }

        private async Task WriteSSHVarFile(FileInfo f)
        {
            List<string> l = new();
            l.Add("variable \"ipaddress\" { default = \"" + MyModel.Server.IP + "\" }");
            l.Add("variable \"username\" { default = \"onfadmin\" }");

            await File.WriteAllLinesAsync(f.FullName, l);
        }

        private async Task WaitOnTask(Task t, TextBlock txt)
        {
            DateTime start = DateTime.Now;

            while (!t.IsCompleted)
            {
                txt.Text = $"Running... {(int)((DateTime.Now - start).TotalSeconds)}s";
                await Task.Delay(1000);
            }

            if (t.IsCompletedSuccessfully)
                txt.Text = "Done";
            else
                txt.Text = "Error!";
        }
    }
}
