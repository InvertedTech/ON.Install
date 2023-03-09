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
    public class FileSystemUserNotificationDataProvider : IUserNotificationDataProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly ILogger logger;

        public FileSystemUserNotificationDataProvider(IOptions<AppSettings> settings, ILogger<FileSystemUserNotificationDataProvider> logger)
        {
            this.logger = logger;

            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("user");
        }

        public async Task<bool> Delete(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return false;

            fd.Delete();

            return true;
        }

        public Task<bool> Exists(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            return Task.FromResult(fd.Exists);
        }

        public async IAsyncEnumerable<UserNotificationSettingsRecord> GetAll()
        {
            foreach (var fd in GetAllDataFiles())
                yield return UserNotificationSettingsRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<UserNotificationSettingsRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            return UserNotificationSettingsRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task Save(UserNotificationSettingsRecord user)
        {
            var id = user.UserIDGuid;
            var fd = GetDataFilePath(id);
            await File.WriteAllBytesAsync(fd.FullName, user.ToByteArray());
        }

        private IEnumerable<FileInfo> GetAllDataFiles()
        {
            return dataDir.EnumerateFiles("*", SearchOption.AllDirectories);
        }

        private FileInfo GetDataFilePath(Guid userID)
        {
            var name = userID.ToString();
            var dir = dataDir.CreateSubdirectory(name.Substring(0, 2)).CreateSubdirectory(name.Substring(2, 2));
            return new FileInfo(dir.FullName + "/" + name);
        }
    }
}
