using ON.Fragments.Settings;
using System;

namespace ON.Settings.SimpleSettings.Service.Models
{
    public class CreateChannelModel
    {
        public string ParentChannelId { get; set; }
        public string DisplayName { get; set; }
        public string UrlStub { get; set; }
        public string ImageAssetId { get; set; }
        public string YoutubeUrl { get; set; }
        public string RumbleUrl { get; set; }

        public bool IsValid()
        {
            ParentChannelId = ParentChannelId.Trim();
            DisplayName = DisplayName.Trim();
            UrlStub = UrlStub.Trim();

            if (string.IsNullOrEmpty(DisplayName))
                return false;
            if (string.IsNullOrEmpty(UrlStub))
                return false;

            if (!string.IsNullOrEmpty(ParentChannelId))
            {
                if (!Guid.TryParse(ParentChannelId, out Guid parentId))
                    return false;
            }

            return true;
        }

        public ChannelRecord ToRecord()
        {
            return new()
            {
                ChannelId = Guid.NewGuid().ToString(),
                DisplayName = DisplayName,
                UrlStub = UrlStub,
                ParentChannelId = ParentChannelId,
                ImageAssetId = ImageAssetId,
                YoutubeUrl = YoutubeUrl,
                RumbleUrl = RumbleUrl,
            };
        }
    }
}
