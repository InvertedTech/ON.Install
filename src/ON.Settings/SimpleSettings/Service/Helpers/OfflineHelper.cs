using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ON.Settings.SimpleSettings.Service.Models;
using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Settings.SimpleSettings.Service.Helpers
{
    public class OfflineHelper
    {
        private readonly ILogger<OfflineHelper> logger;
        private readonly DirectoryInfo rootDir;
        private readonly FileInfo file;
        private readonly FileSystemWatcher watcher;

        public OfflineHelper(IOptions<AppSettings> settings, ILogger<OfflineHelper> logger)
        {
            this.logger = logger;

            rootDir = new DirectoryInfo(settings.Value.DataStore);
            rootDir.Create();
            file = new FileInfo(rootDir.FullName + "/offline");

            watcher = new FileSystemWatcher(rootDir.FullName);

            watcher.NotifyFilter = NotifyFilters.FileName;

            watcher.Created += OnChange;
            watcher.Deleted += OnChange;
            watcher.Renamed += OnChange;

            watcher.Filter = file.Name;
            watcher.IncludeSubdirectories = false;
            watcher.EnableRaisingEvents = true;

            OnChange(null, null);
        }

        public ServiceStatusResponse.Types.OnlineStatus CurrentStatus { get; private set; } = ServiceStatusResponse.Types.OnlineStatus.Online;
        public bool IsOffline { get => CurrentStatus != ServiceStatusResponse.Types.OnlineStatus.Online; }

        public void BringOnline()
        {
            try
            {
                file.Delete();
            } catch
            {
                logger.LogError("Unable to Bring Online");
            }
        }

        public void TakeOffline()
        {
            try
            {
                File.Create(file.FullName).Close();
            }
            catch
            {
                logger.LogError("Unable to Bring Online");
            }
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            file.Refresh();
            if (file.Exists)
                CurrentStatus = ServiceStatusResponse.Types.OnlineStatus.Offline;
            else
                CurrentStatus = ServiceStatusResponse.Types.OnlineStatus.Online;

            logger.LogError("Status: " + (CurrentStatus == ServiceStatusResponse.Types.OnlineStatus.Online ? "Online" : "Offline"));
        }
    }
}
