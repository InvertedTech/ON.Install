using Google.Protobuf;
using Microsoft.Extensions.Options;
using ON.Settings.SimpleSettings.Service.Models;
using ON.Fragments.Authentication;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ON.Fragments.Settings;

namespace ON.Settings.SimpleSettings.Service.Data
{
    public class FileSettingsDataProvider : ISettingsDataProvider
    {
        private readonly FileInfo dataFile;

        public FileSettingsDataProvider(IOptions<AppSettings> settings)
        {
            var root = new DirectoryInfo(settings.Value.DataStore);
            root.Create();
            dataFile = new FileInfo(Path.Combine(root.FullName, "settings"));
        }

        public async Task Clear()
        {
            dataFile.Delete();
            await File.WriteAllTextAsync(dataFile.FullName, "");
        }

        public async Task<SettingsRecord> Get()
        {
            if (!dataFile.Exists || dataFile.Length == 0)
                return null;

            var last = (await File.ReadAllLinesAsync(dataFile.FullName)).Last();

            return SettingsRecord.Parser.ParseFrom(Convert.FromBase64String(last));
        }

        public async IAsyncEnumerable<SettingsRecord> GetAll()
        {
            foreach (var line in await File.ReadAllLinesAsync(dataFile.FullName))
                yield return SettingsRecord.Parser.ParseFrom(Convert.FromBase64String(line));
        }

        public async Task Save(SettingsRecord record)
        {
            await File.AppendAllTextAsync(dataFile.FullName, Convert.ToBase64String(record.ToByteArray()) + "\n");
        }
    }
}
