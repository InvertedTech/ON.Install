using EventStore.Client;
using Google.Protobuf;
using System.Text;

namespace ON.Content.SimpleStats.Service.Helper
{
    public static class IMessageExtension
    {
        public static EventData ToEventData(this IMessage record)
        {
            var json = JsonFormatter.Default.Format(record);

            return new EventData(
                Uuid.NewUuid(),
                record.GetType().ToString(),
                Encoding.ASCII.GetBytes(json)
            );
        }

        public static EventData[] ToEventDataArray(this IMessage record)
        {
            var json = JsonFormatter.Default.Format(record);

            return new[] { new EventData(
                Uuid.NewUuid(),
                record.GetType().ToString(),
                Encoding.ASCII.GetBytes(json)
            ) };
        }
    }
}
