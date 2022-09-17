using ON.Fragments.Settings;
using ON.SimpleWeb.Helper;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace ON.SimpleWeb.Services
{
    public class SettingsService
    {
        private readonly ServiceNameHelper nameHelper;
        private SettingsPublicData publicData = null;

        public Lazy<ChannelRecord> CastCastle;
        public Lazy<ChannelRecord> ChickenCity;
        public Lazy<ChannelRecord> PopCultureCrisis;
        public Lazy<ChannelRecord> InvertedWorld;
        public Lazy<ChannelRecord> Timcast;
        public Lazy<ChannelRecord> TimcastIrl;
        public Lazy<ChannelRecord> TimcastPool;

        public SettingsService(ServiceNameHelper nameHelper)
        {
            this.nameHelper = nameHelper;

            CastCastle = new Lazy<ChannelRecord>(() => GetChannelBySlug("cast-castle").Result);
            ChickenCity = new Lazy<ChannelRecord>(() => GetChannelBySlug("chicken-city").Result);
            PopCultureCrisis = new Lazy<ChannelRecord>(() => GetChannelBySlug("pop-culture-crisis").Result);
            InvertedWorld = new Lazy<ChannelRecord>(() => GetChannelBySlug("tales-from-the-inverted-world").Result);
            Timcast = new Lazy<ChannelRecord>(() => GetChannelBySlug("timcast").Result);
            TimcastIrl = new Lazy<ChannelRecord>(() => GetChannelBySlug("timcast-irl").Result);
            TimcastPool = new Lazy<ChannelRecord>(() => GetChannelBySlug("tim-pool").Result);
        }

        public async Task<SettingsPublicData> GetSettings()
        {
            if (publicData != null)
                return publicData;

            var client = new SettingsInterface.SettingsInterfaceClient(nameHelper.SettingsServiceChannel);
            var res = await client.GetPublicDataAsync(new());

            publicData = res.Public;

            return publicData;
        }

        public async Task<CategoryRecord> GetCategoryById(string id)
        {
            var settings = await GetSettings();

            return settings.CMS.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public async Task<CategoryRecord> GetCategoryBySlug(string slug)
        {
            var settings = await GetSettings();

            return settings.CMS.Categories.FirstOrDefault(c => c.UrlStub == slug);
        }

        public async Task<ChannelRecord> GetChannelById(string id)
        {
            var settings = await GetSettings();

            return settings.CMS.Channels.FirstOrDefault(c => c.ChannelId == id);
        }

        public async Task<ChannelRecord> GetChannelBySlug(string slug)
        {
            var settings = await GetSettings();

            return settings.CMS.Channels.FirstOrDefault(c => c.UrlStub == slug);
        }
    }
}
