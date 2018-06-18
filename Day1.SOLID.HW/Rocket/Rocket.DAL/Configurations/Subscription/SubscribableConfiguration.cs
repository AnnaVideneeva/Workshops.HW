using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Subscription;

namespace Rocket.DAL.Configurations.Subscription
{
    public class SubscribableConfiguration : EntityTypeConfiguration<SubscribableEntity>
    {
        public SubscribableConfiguration()
        {
            ToTable("Subscribable")
                .HasKey(s => s.Id)
                .Property(f => f.Id)
                .HasColumnName("Id");

            HasMany(s => s.Users)
                .WithMany(u => u.Subscriptions)
                .Map(m =>
                {
                    m.ToTable("SubscriptionsToUsers");
                    m.MapLeftKey("SubscriptionId");
                    m.MapRightKey("UserId");
                });
        }
    }
}
