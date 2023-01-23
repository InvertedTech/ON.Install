using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Paypal.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Paypal.Data
{
    public class FileSystemSubscriptionRecordProvider : ISubscriptionRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemSubscriptionRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("paypal").CreateSubdirectory("sub");
        }

        public async Task<PaypalSubscriptionRecord?> GetById(Guid userId, Guid subscriptionId)
        {
            var fd = GetDataFilePath(userId, subscriptionId);
            if (!fd.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fd.FullName)).Where(l => l.Length != 0).Last();

            return PaypalSubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task<List<PaypalSubscriptionRecord>> GetAllByUserId(Guid userId)
        {
            List<PaypalSubscriptionRecord> list = new();

            var dir = GetDataDirPath(userId);
            foreach (var fi in dir.GetFiles())
            {
                if (Guid.TryParse(fi.Name, out var subscriptionId))
                {
                    var rec = await GetById(userId, subscriptionId);
                    if (rec != null)
                        list.Add(rec);
                }
            }

            return list;
        }

        public async Task Save(PaypalSubscriptionRecord rec)
        {
            var id = Guid.Parse(rec.UserID);
            var fd = GetDataFilePath(rec);
            await File.AppendAllTextAsync(fd.FullName, Convert.ToBase64String(rec.ToByteArray()) + "\n");
        }

        private DirectoryInfo GetDataDirPath(PaypalSubscriptionRecord rec)
        {
            var userId = Guid.Parse(rec.UserID);
            return GetDataDirPath(userId);
        }

        private DirectoryInfo GetDataDirPath(Guid userId)
        {
            var name = userId.ToString();
            return dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2)).CreateSubdirectory(name);
        }

        private FileInfo GetDataFilePath(PaypalSubscriptionRecord rec)
        {
            var userId = Guid.Parse(rec.UserID);
            var subscriptionId = Guid.Parse(rec.SubscriptionID);
            return GetDataFilePath(userId, subscriptionId);
        }

        private FileInfo GetDataFilePath(Guid userId, Guid subscriptionId)
        {
            var name = subscriptionId.ToString();
            var dir = GetDataDirPath(userId);
            return new FileInfo(dir.FullName + "/" + name);
        }
    }
}
