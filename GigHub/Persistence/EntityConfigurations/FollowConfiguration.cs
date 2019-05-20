using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class FollowConfiguration : EntityTypeConfiguration<Follow>
    {
        public FollowConfiguration()
        {
            HasKey(k => new {k.FollowerId, k.FollowedId});

            Property(f => f.FollowerId)
                .HasColumnOrder(1);

            Property(f => f.FollowedId)
                .HasColumnOrder(2);

            HasRequired(f => f.Followed)
                .WithMany()
                .WillCascadeOnDelete(false);
        }
    }
}