using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Crypto.Service.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payments.Crypto;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Crypto.Service.Data
{
    public class FileSystemBitcoinPaymentHistoryRecordProvider : IBitcoinPaymentHistoryRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemBitcoinPaymentHistoryRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("payments");
        }

        public async Task<BitcoinPaymentHistoryRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fd.FullName)).Last();

            return BitcoinPaymentHistoryRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task<List<BitcoinPaymentHistoryRecord>> GetAllById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var lines = await File.ReadAllLinesAsync(fd.FullName);

            return lines.Select(l => BitcoinPaymentHistoryRecord.Parser.ParseFrom(Convert.FromBase64String(l))).ToList();
        }

        public async Task Save(BitcoinPaymentHistoryRecord rec)
        {
            var id = new Guid(rec.UserID);
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
