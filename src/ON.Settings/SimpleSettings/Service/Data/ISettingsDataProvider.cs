using ON.Fragments.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Settings.SimpleSettings.Service.Data
{
    public interface ISettingsDataProvider
    {
        Task Clear();
        IAsyncEnumerable<SettingsRecord> GetAll();
        Task<SettingsRecord> Get();
        Task Save(SettingsRecord record);
    }
}
