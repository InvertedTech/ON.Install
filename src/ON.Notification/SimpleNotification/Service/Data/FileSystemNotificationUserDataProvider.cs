using Google.Protobuf;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Notification.SimpleNotification.Service.Models;
using ON.Notification.SimpleNotification.Service.Services;
using ON.Fragments.Authentication;
using ON.Fragments.Generic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ON.Fragments.Notification;

namespace ON.Notification.SimpleNotification.Service.Data
{
    public class FileSystemNotificationUserDataProvider : INotificationUserDataProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly ILogger logger;
        private readonly ConcurrentDictionary<string, Guid> loginIndex = new();

        public FileSystemNotificationUserDataProvider(IOptions<AppSettings> settings, ILogger<FileSystemNotificationUserDataProvider> logger)
        {
            this.logger = logger;

            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("notification");
        }

        public async Task<bool> Delete(string tokenId)
        {
            var fd = GetDataFilePath(NotificationUserRecord.GenerateHash(tokenId));
            if (!fd.Exists)
                return false;

            var rec = UserRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
            fd.Delete();

            loginIndex.TryRemove(rec.Normal.Public.Data.UserName, out var dummy);

            return true;
        }

        public Task<bool> Exists(string tokenId)
        {
            var fd = GetDataFilePath(NotificationUserRecord.GenerateHash(tokenId));
            return Task.FromResult(fd.Exists);
        }

        public async IAsyncEnumerable<NotificationUserRecord> GetAll()
        {
            foreach (var fd in GetAllDataFiles())
                yield return NotificationUserRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<NotificationUserRecord> GetByTokenId(string tokenId)
        {
            var fd = GetDataFilePath(NotificationUserRecord.GenerateHash(tokenId));
            if (!fd.Exists)
                return null;

            var record = NotificationUserRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));

            if (record.TokenID != tokenId)
                return null;

            return record;
        }

        public async Task Save(NotificationUserRecord record)
        {
            var fd = GetDataFilePath(record.TokenHash);
            await File.WriteAllBytesAsync(fd.FullName, record.ToByteArray());
        }

        private IEnumerable<FileInfo> GetAllDataFiles()
        {
            return dataDir.EnumerateFiles("*", SearchOption.AllDirectories);
        }

        private FileInfo GetDataFilePath(string tokenHash)
        {
            var name = tokenHash;
            var dir = dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2));
            return new FileInfo(dir.FullName + "/" + name);
        }
    }
}
