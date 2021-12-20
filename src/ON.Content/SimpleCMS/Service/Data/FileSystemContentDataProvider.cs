using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Content.SimpleCMS.Service.Models;
using ON.Fragments.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Content.SimpleCMS.Service.Data
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

        public async Task<IEnumerable<ContentRecord>> GetAll()
        {
            List<ContentRecord> items = new List<ContentRecord>();
            foreach (var file in contentDir.GetFiles())
            {
                items.Add(ContentRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(file.FullName)));
            }

            return items.OrderByDescending(i => i.Public.CreatedOnUTC);
        }

        public async Task<ContentRecord> GetById(Guid contentId)
        {
            var fd = GetContentFilePath(contentId);
            if (!fd.Exists)
                return null;

            return ContentRecord.Parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task Save(ContentRecord content)
        {
            var id = new Guid(content.Public.ContentID.Span);
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
