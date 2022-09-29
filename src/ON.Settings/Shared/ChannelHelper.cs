using ON.Fragments.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ON.Settings
{
    public class ChannelHelper
    {
        private readonly SettingsClient settingsClient;

        public ChannelHelper(SettingsClient settingsClient)
        {
            this.settingsClient = settingsClient;
        }

        public async Task<ChannelRecord> GetChannelById(string id)
        {
            return (await settingsClient.GetPublicData()).CMS.Channels.FirstOrDefault(c => c.ChannelId == id);
        }

        public async Task<ChannelRecord> GetChannelBySlug(string slug)
        {
            return (await settingsClient.GetPublicData()).CMS.Channels.FirstOrDefault(c => c.UrlStub == slug);
        }
    }
}
