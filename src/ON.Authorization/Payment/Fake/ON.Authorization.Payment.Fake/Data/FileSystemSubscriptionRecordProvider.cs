using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authorization.Payment.Fake.Models;
using ON.Fragments.Authorization;
using ON.Fragments.Authorization.Payment.Fake;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authorization.Payment.Fake.Data
{
    public class FileSystemSubscriptionRecordProvider : ISubscriptionRecordProvider
    {
        private readonly DirectoryInfo dataDir;

        public FileSystemSubscriptionRecordProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("fake");
        }

        public async Task<FakeSubscriptionRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            var last = (await File.ReadAllLinesAsync(fd.FullName)).Last();

            return FakeSubscriptionRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async Task Save(FakeSubscriptionRecord rec)
        {
            var id = Guid.Parse(rec.UserID);
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
