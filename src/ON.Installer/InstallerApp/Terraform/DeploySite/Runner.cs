using Microsoft.IdentityModel.Tokens;
using ON.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.DeploySite
{
    internal class Runner
    {
        internal static async Task DeploySite(DeployWindow window)
        {
            await window.AddLine("--- Deploy Site ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/deploySite");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");
            var envF = new FileInfo(targetD.FullName + "/.env");

            if (!targetD.Exists)
            {
                targetD.Create();
                await window.resHelper.SaveDeploySite(targetD);
            }

            var ssh = window.keyHelper.DeriveEcSshKey();
            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = window.MyModel.Server.IP;
            envVars["username"] = window.MyModel.Server.User;
            envVars["sshPriv"] = ssh.privKey;

            await WriteEnvFile(window, envF);

            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);
        }

        private static async Task WriteEnvFile(DeployWindow window, FileInfo f)
        {
            var jwtKey = window.keyHelper.DeriveEcJwtKey();

            List<string> l = new();
            l.Add("SUBSCRIPTION_TIERS=" + Base64UrlEncoder.Encode(JsonSerializer.Serialize(window.MyModel.Payment.SubscriptionTiers)));
            l.Add("WEBSITE_NAME=" + Base64UrlEncoder.Encode(window.MyModel.Personalization.Name));
            l.Add("WEBSITE_DESC=" + Base64UrlEncoder.Encode(window.MyModel.Personalization.Description));
            l.Add("DNSNAME=" + window.MyModel.DNS.Name);
            l.Add("JWTPRIV=" + jwtKey.ToPrivateEncodedJsonWebKey());
            l.Add("JWTPUB=" + jwtKey.ToPublicEncodedJsonWebKey());
            l.Add("PAYPAL_API_KEY=" + window.MyModel.Payment.PayPalApiKey);
            l.Add("STRIPE_API_KEY=" + window.MyModel.Payment.StripeApiKey);

            await File.WriteAllLinesAsync(f.FullName, l);
        }
    }
}
