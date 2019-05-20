using System.Collections.Generic;
using GigHub.Core.Models;

namespace GigHub.Core.Repositories
{
    public interface INotificationsRepository
    {
        IEnumerable<Notification> GetNotificationsForCurrentUser(string userId);
        List<UserNotification> GetUnreadNotifications(string userId);
    }
}