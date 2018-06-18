using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения данных о получателе нотификации
    /// </summary>
    public class ReceiverConfiguration : EntityTypeConfiguration<DbReceiver>
    {
        public ReceiverConfiguration()
        {
            ToTable("Receivers");

            HasKey(x => x.UserId);

            Property(x => x.NotifyByEmail).IsRequired();

            Property(x => x.NotifyByPush).IsRequired();

            HasMany(x => x.UserBillingMessages)
                .WithRequired(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverId);

            HasMany(x => x.CustomMessages)
                .WithRequired(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverId);

            HasMany(x => x.ReceiversJoinReleases)
                .WithRequired(x => x.Receiver)
                .HasForeignKey(x => x.ReceiverId);
        }
    }
}