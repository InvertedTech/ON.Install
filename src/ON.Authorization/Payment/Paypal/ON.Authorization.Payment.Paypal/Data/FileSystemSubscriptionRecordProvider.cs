using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Paypal.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Paypal;
using ON.Fragments.Content;
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

        public Task Delete(Guid userId, Guid subscriptionId)
        {
            var fi = GetDataFilePath(userId, subscriptionId);
            if (fi.Exists)
                fi.Delete();

            return Task.CompletedTask;
        }

        public Task<bool> Exists(Guid userId, Guid subscriptionId)
        {
            var fi = GetDataFilePath(userId, subscriptionId);
            return Task.FromResult(fi.Exists);
        }

        public async IAsyncEnumerable<PaypalSubscriptionRecord> GetAll()
        {
            foreach (var fi in dataDir.GetFiles("*", SearchOption.AllDirectories))
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    yield return rec;
            }
        }


        public Task<PaypalSubscriptionRecord?> GetById(Guid userId, Guid subscriptionId)
        {
            var fi = GetDataFilePath(userId, subscriptionId);
            return ReadLastOfFile(fi);
        }

        public async Task<List<PaypalSubscriptionRecord>> GetAllByUserId(Guid userId)
        {
            List<PaypalSubscriptionRecord> list = new();

            var dir = GetDataDirPath(userId);
            foreach (var fi in dir.GetFiles())
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    list.Add(rec);
            }

            return list;
        }

        public async Task Save(PaypalSubscriptionRecord rec)
        {
            var id = Guid.Parse(rec.UserID);
            var fi = GetDataFilePath(rec);
            await File.AppendAllTextAsync(fi.FullName, Convert.ToBase64String(rec.ToByteArray()) + "\n");
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

        private async Task<PaypalSubscriptionRecord?> ReadLastOfFile(FileInfo fi)
        {
            if (!fi.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fi.FullName)).Where(l => l.Length != 0).Last();

            return PaypalSubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }
    }
}
