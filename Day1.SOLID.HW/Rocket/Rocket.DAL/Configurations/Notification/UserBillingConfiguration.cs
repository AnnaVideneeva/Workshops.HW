using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения данных по сообщениям о платежах пользователя
    /// </summary>
    public class UserBillingConfiguration : EntityTypeConfiguration<DbUserBillingMessage>
    {
        public UserBillingConfiguration()
        {
            ToTable("UserBillingMessages");

            HasKey(x => x.Id);

            Property(x => x.Sum).IsRequired();

            Property(x => x.Viewed).IsRequired();

            Property(x => x.CreationTime).IsRequired();
        }
    }
}