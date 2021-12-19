using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Authentication.SimpleAuth.Service.Models;
using ON.Fragments.Authentcation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Authentication.SimpleAuth.Service.Data
{
    public class FileSystemUserDataProvider : IUserDataProvider
    {
        private readonly DirectoryInfo dataDir;
        private readonly DirectoryInfo indexDir;

        public FileSystemUserDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory("data");
            indexDir = root.CreateSubdirectory("index");
        }

        public async Task<bool> Create(UserRecord user)
        {
            var id = new Guid(user.Public.UserID.Span);
            var fd = GetDataFilePath(id);
            var fi = GetIndexFilePath(user.Public.UserName);

            if (fi.Exists || fd.Exists)
                return false;

            await File.WriteAllTextAsync(fi.FullName, id.ToString());

            await File.WriteAllBytesAsync(fd.FullName, user.ToByteArray());

            return true;
        }

        public Task<bool> Delete(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            var res = fd.Exists;
            fd.Delete();
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            return Task.FromResult(fd.Exists);
        }

        public Task<bool> Exists(string loginName)
        {
            var fi = GetIndexFilePath(loginName);
            return Task.FromResult(fi.Exists);
        }

        public async IAsyncEnumerable<UserRecord> GetAll()
        {
            foreach (var fd in GetAllDataFiles())
                yield return UserRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<UserRecord> GetById(Guid userId)
        {
            var fd = GetDataFilePath(userId);
            if (!fd.Exists)
                return null;

            return UserRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<UserRecord> GetByLogin(string loginName)
        {
            var fi = GetIndexFilePath(loginName);
            if (!fi.Exists)
                return null;

            Guid id;
            if (!Guid.TryParse(await File.ReadAllTextAsync(fi.FullName), out id))
                return null;

            return await GetById(id);

        }

        public async Task Save(UserRecord user)
        {
            var id = new Guid(user.Public.UserID.Span);
            var fd = GetDataFilePath(id);
            await File.WriteAllBytesAsync(fd.FullName, user.ToByteArray());
        }

        public async Task ReindexAll()
        {
            TruncateAllIndexes();

            await foreach(var user in GetAll())
            {
                var id = new Guid(user.Public.UserID.Span);
                var fi = GetIndexFilePath(user.Public.UserName);

                await File.WriteAllTextAsync(fi.FullName, id.ToString());
            }
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

        private FileInfo GetIndexFilePath(string loginName)
        {
            var dir = indexDir.CreateSubdirectory(loginName.Substring(0, 2)).CreateSubdirectory(loginName.Substring(2, 2));
            return new FileInfo(dir.FullName + "/" + loginName);
        }

        private void TruncateAllIndexes()
        {
            indexDir.Delete(true);
            indexDir.Create();
        }
    }
}
