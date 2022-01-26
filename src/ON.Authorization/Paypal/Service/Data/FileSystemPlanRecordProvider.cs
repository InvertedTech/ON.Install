using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Paypal.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Paypal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Paypal.Service.Data
{
    public class FileSystemPlanRecordProvider : IPlanRecordProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly FileInfo listFile;

        public FileSystemPlanRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("server");
            listFile = new FileInfo(dataDir.FullName + "/plans");
        }

        public async Task<PlanList> GetAll()
        {
            if (!listFile.Exists)
                return new PlanList();

            var bytes = await File.ReadAllBytesAsync(listFile.FullName);

            return PlanList.Parser.ParseFrom(bytes);
        }

        public async Task SaveAll(PlanList list)
        {
            await File.WriteAllBytesAsync(listFile.FullName, list.ToByteArray());
        }
    }
}
