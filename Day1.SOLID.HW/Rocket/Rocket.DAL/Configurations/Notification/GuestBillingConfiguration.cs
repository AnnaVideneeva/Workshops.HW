using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения данных по сообщениям о донате гостя
    /// </summary>
    public class GuestBillingConfiguration : EntityTypeConfiguration<DbGuestBillingMessage>
    {
        public GuestBillingConfiguration()
        {
            ToTable("GuestBillingMessages");

            HasKey(x => x.Id);

            Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Sum).IsRequired();

            Property(x => x.CreationTime).IsRequired();
        }
    }
}