using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
             Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            HasMany(u => u.UserNotifications)
                .WithRequired(u => u.User)
                .WillCascadeOnDelete(false);
        }
    }
}