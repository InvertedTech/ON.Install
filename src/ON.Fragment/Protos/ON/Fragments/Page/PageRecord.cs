using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Page
{
    public sealed partial class PageListRecord : pb::IMessage<PageListRecord>
    {
        public Guid PageIDGuid
        {
            get => PageID.ToGuid();
            set => PageID = value.ToString();
        }
    }

    public sealed partial class PagePublicRecord : pb::IMessage<PagePublicRecord>
    {
        public Guid PageIDGuid
        {
            get => PageID.ToGuid();
            set => PageID = value.ToString();
        }

        public PageListRecord ToPageListRecord()
        {
            var rec = new PageListRecord()
            {
                PageID = PageID,
                CreatedOnUTC = CreatedOnUTC,
                PublishOnUTC = PublishOnUTC,
                PinnedOnUTC = PinnedOnUTC,
                Title = Data.Title,
                Description = Data.Description,
                SubscriptionLevel = Data.SubscriptionLevel,
                URL = Data.URL,
                Author = Data.Author,
                AuthorID = Data.AuthorID,
                FeaturedImageAssetID = Data.FeaturedImageAssetID,
            };

            return rec;
        }
    }
}