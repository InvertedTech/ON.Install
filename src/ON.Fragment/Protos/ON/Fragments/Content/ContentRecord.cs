using ON.Fragments.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pb = global::Google.Protobuf;

namespace ON.Fragments.Content
{
    public sealed partial class ContentListRecord : pb::IMessage<ContentListRecord>
    {
        public Guid ContentIDGuid
        {
            get => ContentID.ToGuid();
            set => ContentID = value.ToString();
        }
    }

    public sealed partial class ContentPublicData : pb::IMessage<ContentPublicData>
    {
        public ContentType GetContentType()
        {
            switch (ContentDataOneofCase)
            {
                case ContentDataOneofOneofCase.Audio:
                    return ContentType.Audio;
                case ContentDataOneofOneofCase.Picture:
                    return ContentType.Picture;
                case ContentDataOneofOneofCase.Written:
                    return ContentType.Written;
                case ContentDataOneofOneofCase.Video:
                    return ContentType.Video;
                default:
                    return ContentType.None;
            }
        }
    }

    public sealed partial class ContentPublicRecord : pb::IMessage<ContentPublicRecord>
    {
        public Guid ContentIDGuid
        {
            get => ContentID.ToGuid();
            set => ContentID = value.ToString();
        }

        public ContentListRecord ToContentListRecord()
        {
            return new()
            {
                ContentID = ContentID,
                CreatedOnUTC = CreatedOnUTC,
                PublishOnUTC = PublishOnUTC,
                Title = Data.Title,
                Description = Data.Description,
                SubscriptionLevel = Data.SubscriptionLevel,
                ContentType = Data.GetContentType(),
            };
        }
    }
}