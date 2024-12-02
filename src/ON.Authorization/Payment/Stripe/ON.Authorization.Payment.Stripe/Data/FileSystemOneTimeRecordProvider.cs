using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Stripe.Models;
using ON.Fragments.Authorization.Payment.Stripe;
using Stripe;

namespace ON.Authorization.Payment.Stripe.Data
{
    public class FileSystemOneTimeRecordProvider : IOneTimeRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemOneTimeRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("stripe").CreateSubdirectory("onetime");
        }

        public Task<bool> Exists(Guid userId, Guid recordId)
        {
            var fi = GetDataFilePath(userId, recordId);
            return Task.FromResult(fi.Exists);
        }

        public async IAsyncEnumerable<StripeOneTimePaymentRecord> GetAll()
        {
            foreach (var fi in dataDir.GetFiles("*", SearchOption.AllDirectories))
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    yield return rec;
            }
        }

        public async Task<List<StripeOneTimePaymentRecord>> GetAllByUserId(Guid userId)
        {
            List<StripeOneTimePaymentRecord> list = new();

            var dir = GetDataDirPath(userId);
            foreach (var fi in dir.GetFiles())
            {
                var rec = await ReadLastOfFile(fi);
                if (rec != null)
                    list.Add(rec);
            }

            return list;
        }

        public Task<StripeOneTimePaymentRecord?> GetById(Guid userId, Guid recordId)
        {
            var fi = GetDataFilePath(userId, recordId);
            return ReadLastOfFile(fi);
        }

        public async Task Save(StripeOneTimePaymentRecord record)
        {
            var id = Guid.Parse(record.UserID);
            var fi = GetDataFilePath(record);
            await System.IO.File.AppendAllTextAsync(
                fi.FullName,
                Convert.ToBase64String(record.ToByteArray()) + "\n"
            );
        }

        private DirectoryInfo GetDataDirPath(Guid userId)
        {
            var name = userId.ToString();
            return dataDir
                .CreateSubdirectory(name.Substring(0, 2))
                .CreateSubdirectory(name.Substring(2, 2))
                .CreateSubdirectory(name);
        }

        private FileInfo GetDataFilePath(StripeOneTimePaymentRecord record)
        {
            var userId = Guid.Parse(record.UserID);
            var paymentId = Guid.Parse(record.InternalID);
            return GetDataFilePath(userId, paymentId);
        }

        private FileInfo GetDataFilePath(Guid userId, Guid internalId)
        {
            var name = internalId.ToString();
            var dir = GetDataDirPath(userId);
            return new FileInfo(dir.FullName + "/" + name);
        }

        private async Task<StripeOneTimePaymentRecord?> ReadLastOfFile(FileInfo fi)
        {
            if (!fi.Exists)
                return null;

            var last = (await System.IO.File.ReadAllLinesAsync(fi.FullName))
                .Where(l => l.Length != 0)
                .Last();

            return StripeOneTimePaymentRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }
    }
}
