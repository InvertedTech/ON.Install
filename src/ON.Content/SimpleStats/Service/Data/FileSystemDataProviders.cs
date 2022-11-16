using Google.Protobuf;
using Google.Protobuf.Reflection;
using Microsoft.Extensions.Options;
using ON.Content.SimpleStats.Service.Models;
using ON.Fragments.Content;
using ON.Fragments.Content.Stats;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ON.Content.SimpleStats.Service.Data
{
    public class FileSystemStatsContentPublicDataProvider : GenericFileSystemDataProvider<StatsContentPublicRecord>, IStatsContentPublicDataProvider
    {
        public FileSystemStatsContentPublicDataProvider(IOptions<AppSettings> settings) : base("cpub", settings) { }
        public Task Save(StatsContentPublicRecord record) => Save(record.ContentID.ToGuid(), record);
    }

    public class FileSystemStatsContentPrivateDataProvider : GenericFileSystemDataProvider<StatsContentPrivateRecord>, IStatsContentPrivateDataProvider
    {
        public FileSystemStatsContentPrivateDataProvider(IOptions<AppSettings> settings) : base("cprv", settings) { }
        public Task Save(StatsContentPrivateRecord record) => Save(record.ContentID.ToGuid(), record);
    }

    public class FileSystemStatsUserPublicDataProvider : GenericFileSystemDataProvider<StatsUserPublicRecord>, IStatsUserPublicDataProvider
    {
        public FileSystemStatsUserPublicDataProvider(IOptions<AppSettings> settings) : base("upub", settings) { }
        public Task Save(StatsUserPublicRecord record) => Save(record.UserID.ToGuid(), record);
    }

    public class FileSystemStatsUserPrivateDataProvider : GenericFileSystemDataProvider<StatsUserPrivateRecord>, IStatsUserPrivateDataProvider
    {
        public FileSystemStatsUserPrivateDataProvider(IOptions<AppSettings> settings) : base("uprv", settings) { }
        public Task Save(StatsUserPrivateRecord record) => Save(record.UserID.ToGuid(), record);
    }

    public class GenericFileSystemDataProvider<T> where T : IMessage<T>
    {
        private readonly DirectoryInfo dataDir;
        private readonly MessageParser<T> parser;

        public GenericFileSystemDataProvider(string dirName, IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataDir = root.CreateSubdirectory(dirName);

            var pi = typeof(T).GetProperty("Parser", BindingFlags.Public | BindingFlags.Static);
            parser = pi.GetValue(null) as MessageParser<T>;
        }

        public Task<bool> Delete(Guid recordId)
        {
            var fd = GetFilePath(recordId);
            var res = fd.Exists;
            fd.Delete();
            return Task.FromResult(res);
        }

        public Task<bool> Exists(Guid recordId)
        {
            var fd = GetFilePath(recordId);
            return Task.FromResult(fd.Exists);
        }

        public async IAsyncEnumerable<T> GetAll()
        {
            foreach (var file in dataDir.GetFiles())
            {
                yield return parser.ParseFrom(await File.ReadAllBytesAsync(file.FullName));
            }
        }

        public async Task<T> GetById(Guid recordId)
        {
            var fd = GetFilePath(recordId);
            if (!fd.Exists)
                return default(T);

            return parser.ParseFrom(await File.ReadAllBytesAsync(fd.FullName));
        }

        public async Task Save(Guid recordId, T record)
        {
            var fd = GetFilePath(recordId);
            await File.WriteAllBytesAsync(fd.FullName, record.ToByteArray());
        }

        private FileInfo GetFilePath(Guid recordId)
        {
            var name = recordId.ToString();
            return new FileInfo(dataDir.FullName + "/" + name);
        }
    }
}
