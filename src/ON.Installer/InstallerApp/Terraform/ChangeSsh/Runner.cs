using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.ChangeSsh
{
    internal class Runner
    {
        public static async Task ChangeSshKey(DeployWindow window, string tempSshPriv)
        {
            await window.AddLine("--- Changing SSH Key ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/changeSsh");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");

            if (!targetD.Exists)
            {
                targetD.Create();
                await window.resHelper.SaveChangeSSH(targetD);
            }

            var ssh = window.keyHelper.DeriveEcSshKey();

            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = window.MyModel.Server.IP;
            envVars["username"] = window.MyModel.Server.User;
            envVars["tempSshPriv"] = tempSshPriv;
            envVars["sshPub"] = ssh.pubKey;

            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);
        }
    }
}
