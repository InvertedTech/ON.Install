using ON.Fragments.Authentication;
using ON.Fragments.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ON.Notification.SimpleNotification.Service.Data
{
    public interface IUserNotificationDataProvider
    {
        Task<bool> Delete(Guid userId);
        Task<bool> Exists(Guid userId);
        IAsyncEnumerable<UserNotificationSettingsRecord> GetAll();
        Task<UserNotificationSettingsRecord> GetById(Guid userId);
        Task Save(UserNotificationSettingsRecord user);
    }
}
