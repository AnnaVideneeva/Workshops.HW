using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels;

namespace Rocket.DAL.Configurations
{
    /// <summary>
    /// Конфигурация хранения данных по сообщениям о платежах пользователя
    /// </summary>
    public class UserPaymentConfiguration : EntityTypeConfiguration<DbUserPayment>
    {
        public UserPaymentConfiguration()
        {
            ToTable("UserPayments");

            HasKey(x => x.Id);

            Property(x => x.UserId).IsRequired();

            Property(x => x.PaymentID).IsRequired();
        }
    }
}