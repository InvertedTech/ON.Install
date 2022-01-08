using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.CreateServer.Azure
{
    internal class Runner
    {
        internal static async Task CreateServerAzure(DeployWindow window)
        {
            await window.AddLine("--- Create Server ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/createServer/azure");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                await window.resHelper.SaveCreateAzure(targetD);
            }

            var ssh = Security.SshHelper.CreateRSAKey("temp@onf");
            var envVars = new Dictionary<string, string>();
            envVars["prefix"] = "onf-" + window.MyModel.DNS.Name.Replace(".", "-");
            envVars["location"] = "centralus";
            envVars["username"] = "onfadmin";
            envVars["sshPub"] = ssh.pubKey;


            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);
            await window.terraformHelper.RunTerraform(targetD, "refresh", envVars);

            var addyLine = (await File.ReadAllLinesAsync(targetD.FullName + "/terraform.tfstate")).FirstOrDefault(l => l.Contains("\"public_ip_address\""));
            var addy = addyLine.GetBetween(": \"", "\"");
            window.MyModel.Server.IP = addy;
            window.MyModel.Server.User = "onfadmin";

            await Terraform.ChangeSsh.Runner.ChangeSshKey(window, ssh.privKey);
        }
    }
}
