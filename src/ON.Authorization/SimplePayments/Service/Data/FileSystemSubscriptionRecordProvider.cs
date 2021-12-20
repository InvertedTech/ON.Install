using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.SimplePayments.Service.Models;
using ON.Fragments.Authorization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.SimplePayments.Service.Data
{
    public class FileSystemSubscriptionRecordProvider : ISubscriptionRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemSubscriptionRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("data");
        }

        public async Task<SubscriptionRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fd.FullName)).Last();

            return SubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task<IEnumerable<SubscriptionRecord>> GetAllById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var lines = await File.ReadAllLinesAsync(fd.FullName);

            return lines.Select(l => SubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(l)));
        }

        public async Task Save(SubscriptionRecord rec)
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
