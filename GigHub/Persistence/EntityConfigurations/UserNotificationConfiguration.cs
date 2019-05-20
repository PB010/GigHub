using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class UserNotificationConfiguration :EntityTypeConfiguration<UserNotification>
    {
        public UserNotificationConfiguration()
        {
            HasKey(k => new {k.UserId, k.NotificationId});

            Property(n => n.UserId)
                .HasColumnOrder(1);

            Property(n => n.NotificationId)
                .HasColumnOrder(2);
        }
    }
}