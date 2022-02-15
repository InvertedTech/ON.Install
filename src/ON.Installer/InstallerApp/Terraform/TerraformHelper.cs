using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallerApp.Terraform
{
    internal class TerraformHelper
    {
        DeployWindow window;

        public TerraformHelper(DeployWindow window)
        {
            this.window = window;
        }

        public async Task RunTerraform(DirectoryInfo d, string extra, Dictionary<string, string> envVars = null)
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

        private void P_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            window.AddLine(e.Data).Wait();
        }
    }
}
