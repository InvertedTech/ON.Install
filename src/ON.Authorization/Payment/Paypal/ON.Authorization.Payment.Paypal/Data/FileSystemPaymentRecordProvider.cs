using Google.Protobuf;
using Google.Protobuf.Collections;
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
    public class FileSystemPaymentRecordProvider : IPaymentRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemPaymentRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("paypal").CreateSubdirectory("pay");
        }

        public Task Delete(Guid userId, Guid subscriptionId, Guid paymentId)
        {
            var fi = GetDataFilePath(userId, subscriptionId, paymentId);
            if (fi.Exists)
                fi.Delete();

            return Task.CompletedTask;
        }

        public Task DeleteAll(Guid userId, Guid subscriptionId)
        {
            GetDataDirPath(userId, subscriptionId).Delete();

            return Task.CompletedTask;
        }

        public Task<bool> Exists(Guid userId, Guid subscriptionId, Guid paymentId)
        {
            var fi = GetDataFilePath(userId, subscriptionId, paymentId);
            return Task.FromResult(fi.Exists);
        }
        public async Task<PaypalPaymentRecord?> GetById(Guid userId, Guid subscriptionId, Guid paymentId)
        {
            var fi = GetDataFilePath(userId, subscriptionId, paymentId);
            return await ReadLastOfFile(fi);
        }

        public async Task<List<PaypalPaymentRecord>> GetAllByUserId(Guid userId)
        {
            List<PaypalPaymentRecord> list = new();

            var dir = GetDataDirPath(userId);
            foreach (var fi in dir.GetFiles("*", SearchOption.AllDirectories))
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    list.Add(rec);
            }

            return list;
        }

        public async Task<List<PaypalPaymentRecord>> GetAllBySubscriptionId(Guid userId, Guid subscriptionId)
        {
            List<PaypalPaymentRecord> list = new();

            var dir = GetDataDirPath(userId, subscriptionId);
            foreach (var fi in dir.GetFiles())
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    list.Add(rec);
            }

            return list;
        }

        public async Task Save(PaypalPaymentRecord rec)
        {
            var id = Guid.Parse(rec.UserID);
            var fd = GetDataFilePath(rec);
            await File.AppendAllTextAsync(fd.FullName, Convert.ToBase64String(rec.ToByteArray()) + "\n");
        }

        private DirectoryInfo GetDataDirPath(PaypalPaymentRecord rec)
        {
            var userId = Guid.Parse(rec.UserID);
            var subscriptionId = Guid.Parse(rec.SubscriptionID);
            return GetDataDirPath(userId, subscriptionId);
        }

        private DirectoryInfo GetDataDirPath(Guid userId)
        {
            var name = userId.ToString();
            return dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2)).CreateSubdirectory(name);
        }

        private DirectoryInfo GetDataDirPath(Guid userId, Guid subscriptionId)
        {
            return GetDataDirPath(userId).CreateSubdirectory(subscriptionId.ToString());
        }

        private FileInfo GetDataFilePath(PaypalPaymentRecord rec)
        {
            var userId = Guid.Parse(rec.UserID);
            var subscriptionId = Guid.Parse(rec.SubscriptionID);
            var paymentId = Guid.Parse(rec.PaymentID);
            return GetDataFilePath(userId, subscriptionId, paymentId);
        }

        private FileInfo GetDataFilePath(Guid userId, Guid subscriptionId, Guid paymentId)
        {
            var dir = GetDataDirPath(userId, subscriptionId);
            return new FileInfo(dir.FullName + "/" + paymentId.ToString());
        }

        private async Task<PaypalPaymentRecord?> ReadLastOfFile(FileInfo fi)
        {
            if (!fi.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fi.FullName)).Where(l => l.Length != 0).Last();

            return PaypalPaymentRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task SaveAll(IEnumerable<PaypalPaymentRecord> payments)
        {
            foreach (var p in payments)
            {
                await Save(p);
            }
        }
    }
}
