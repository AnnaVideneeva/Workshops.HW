using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    public class NotificationsSettingsEntityMap : EntityTypeConfiguration<NotificationsSettingsEntity>
    {
        public NotificationsSettingsEntityMap()
        {
            ToTable("NotificationsSettings")
                .HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(50);

            Property(p => p.NotifyIsSwitchOn)
                .IsRequired()
                .HasColumnName("NotifyIsSwitchOn");

            Property(p => p.NotifyPeriodInMinutes)
                .IsRequired()
                .HasColumnName("NotifyPeriodInMinutes");

            Property(p => p.PushUrl)
                .IsRequired()
                .HasColumnName("PushUrl")
                .HasMaxLength(100);
        }
    }
}
