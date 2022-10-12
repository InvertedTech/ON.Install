using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.SimpleStats.Service.Models;
using ON.Fragments.Content;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public class FileSystemContentDataProvider : IContentDataProvider
    {
        private readonly DirectoryInfo contentDir;

        public FileSystemContentDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            contentDir = root.CreateSubdirectory("content");
        }

        public Task<bool> Delete(Guid userId)
        {
            var fd = GetContentFilePath(userId);
            var res = fd.Exists;
            fd.Delete();
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid userId)
        {
            var fd = GetContentFilePath(userId);
            return Task.FromResult(fd.Exists);
        }

        public async IAsyncEnumerable<ContentRecord> GetAll()
        {
            foreach (var file in contentDir.GetFiles())
            {
                yield return ContentRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(file.FullName));
            }
        }

        public async Task<ContentRecord> GetById(Guid contentId)
        {
            var fd = GetContentFilePath(contentId);
            if (!fd.Exists)
                return null;

            return ContentRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task<ContentRecord> GetByURL(string url)
        {
            await foreach(var rec in GetAll())
            {
                if (rec.Public.Data.URL == url)
                    return rec;
            }

            return null;
        }

        public async Task Save(ContentRecord content)
        {
            var id = content.Public.ContentID.ToGuid();
            var fd = GetContentFilePath(id);
            await File.WriteAllBytesAsync(fd.FullName, content.ToByteArray());
        }

        private FileInfo GetContentFilePath(Guid contentId)
        {
            var name = contentId.ToString();
            return new FileInfo(contentDir.FullName + "/" + name);
        }
    }
}
