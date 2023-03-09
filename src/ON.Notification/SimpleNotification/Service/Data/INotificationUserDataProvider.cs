using ON.Fragments.Authentication;
using ON.Fragments.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Notification.SimpleNotification.Service.Data
{
    public interface INotificationUserDataProvider
    {
        Task<bool> Delete(string tokenId);
        Task<bool> Exists(string tokenId);
        IAsyncEnumerable<NotificationUserRecord> GetAll();
        Task<NotificationUserRecord> GetByTokenId(string tokenId);
        Task Save(NotificationUserRecord user);
    }
}
