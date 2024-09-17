using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Stripe.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Stripe;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Stripe.Data
{
    public class FileSystemSubscriptionRecordProvider : ISubscriptionRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemSubscriptionRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("stripe").CreateSubdirectory("sub");
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

        public async IAsyncEnumerable<StripeSubscriptionRecord> GetAll()
        {
            foreach (var fi in dataDir.GetFiles("*", SearchOption.AllDirectories))
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    yield return rec;
            }
        }


        public Task<StripeSubscriptionRecord?> GetById(Guid userId, Guid subscriptionId)
        {
            var fi = GetDataFilePath(userId, subscriptionId);
            return ReadLastOfFile(fi);
        }

        public async Task<List<StripeSubscriptionRecord>> GetAllByUserId(Guid userId)
        {
            List<StripeSubscriptionRecord> list = new();

            var dir = GetDataDirPath(userId);
            foreach (var fi in dir.GetFiles())
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    list.Add(rec);
            }

            return list;
        }

        public async Task Save(StripeSubscriptionRecord rec)
        {
            var id = Guid.Parse(rec.UserID);
            var fi = GetDataFilePath(rec);
            await File.AppendAllTextAsync(fi.FullName, Convert.ToBase64String(rec.ToByteArray()) + "\n");
        }

        private DirectoryInfo GetDataDirPath(StripeSubscriptionRecord rec)
        {
            var userId = Guid.Parse(rec.UserID);
            return GetDataDirPath(userId);
        }

        private DirectoryInfo GetDataDirPath(Guid userId)
        {
            var name = userId.ToString();
            return dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2)).CreateSubdirectory(name);
        }

        private FileInfo GetDataFilePath(StripeSubscriptionRecord rec)
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

        private async Task<StripeSubscriptionRecord?> ReadLastOfFile(FileInfo fi)
        {
            if (!fi.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fi.FullName)).Where(l => l.Length != 0).Last();

            return StripeSubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }
    }
}
