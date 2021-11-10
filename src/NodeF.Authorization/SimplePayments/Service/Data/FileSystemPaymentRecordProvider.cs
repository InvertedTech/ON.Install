using Google.Protobuf;
using Microsoft.Extensions.Options;
using NodeF.Authorization.SimplePayments.Service.Models;
using NodeF.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NodeF.Authorization.SimplePayments.Service.Data
{
    public class FileSystemPaymentRecordProvider : IPaymentRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemPaymentRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("data");
        }

        public async Task<PaymentRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fd.FullName)).Last();

            return PaymentRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task<IEnumerable<PaymentRecord>> GetAllById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var lines = await File.ReadAllLinesAsync(fd.FullName);

            return lines.Select(l => PaymentRecord.Parser.ParseFrom(Convert.FromBase64String(l)));
        }

        public async Task Save(PaymentRecord rec)
        {
            var id = new Guid(rec.UserID.Span);
            var fd = GetDataFilePath(id);
            await File.AppendAllTextAsync(fd.FullName, Convert.ToBase64String(rec.ToByteArray()) + "\n");
        }

        private FileInfo GetDataFilePath(Guid userID)
        {
            var name = userID.ToString();
            var dir = dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2));
            return new FileInfo(dir.FullName + "/" + name);
        }
    }
}
