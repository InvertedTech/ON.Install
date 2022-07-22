using InstallerApp.Models;
using Microsoft.IdentityModel.Tokens;
using ON.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InstallerApp.Terraform.Deploy.Business
{
    internal class Runner
    {
        internal static async Task DeploySite(DeployWindow window)
        {
            await window.AddLine("--- Deploy Site ---");

            var targetD = new DirectoryInfo($"{window.DeployRootD.FullName}/deploy/business");
            var terraD = new DirectoryInfo(targetD.FullName + "/.terraform");
            var varF = new FileInfo(targetD.FullName + "/variables.tf");
            var jsonF = new FileInfo(targetD.FullName + "/defaults.json");

            if (!targetD.Exists)
            {
                targetD.Create();
                await window.resHelper.SaveDeployBusiness(targetD);
            }

            var ssh = window.keyHelper.DeriveEcSshKey();
            var envVars = new Dictionary<string, string>();
            envVars["ipaddress"] = window.MyModel.Server.IP;
            envVars["username"] = window.MyModel.Server.User;
            envVars["sshPriv"] = ssh.privKey;

            await WriteJsonFile(window, jsonF);

            if (!terraD.Exists)
            {
                await window.terraformHelper.RunTerraform(targetD, "init", envVars);
            }

            await window.terraformHelper.RunTerraform(targetD, "apply -auto-approve", envVars);
        }

        private static async Task WriteJsonFile(DeployWindow window, FileInfo f)
        {
            BusinessDataModel model = new()
            {
                BusinessName = window.MyModel.Personalization.Name,
                BusinessTagLine = window.MyModel.Personalization.Description,
                Phone = window.MyModel.Business.Phone,
                WhatWeDo = window.MyModel.Business.WhatWeDo,
                AboutUs = window.MyModel.Business.AboutUs,
            };

            for (int i = 1; i <= 7; i++)
                model.Carousel.Add($"{i}.jpg");

            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Mon", Start = "9:00am", End = "6:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Tue", Start = "9:00am", End = "6:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Wed", Start = "9:00am", End = "6:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Thu", Start = "9:00am", End = "6:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Fri", Start = "9:00am", End = "6:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Sat", Start = "9:00am", End = "2:00pm" });
            model.Hours.Add(new BusinessDataModel.HoursModel() { Day = "Sun", Start = "", End = "" });

            string json = JsonSerializer.Serialize(model);

            await File.WriteAllTextAsync(f.FullName, json);
        }
    }
}
