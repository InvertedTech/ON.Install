using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.InstallDocker
{
    internal class Runner
    {
        internal static async Task InstallDocker(DeployWindow window)
        {
            if (!window.needDockerInstalled)
            {
                await window.AddLine("--- Skipping Docker Install ---");
                return;
            }

            await window.AddLine("--- Install Docker ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/installDocker");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");

            if (!targetD.Exists)
            {
                targetD.Create();
                await window.resHelper.SaveInstallDocker(targetD);
            }

            var ssh = window.keyHelper.DeriveEcSshKey();
            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = window.MyModel.Server.IP;
            envVars["username"] = window.MyModel.Server.User;
            envVars["sshPriv"] = ssh.privKey;

            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);
        }
    }
}
