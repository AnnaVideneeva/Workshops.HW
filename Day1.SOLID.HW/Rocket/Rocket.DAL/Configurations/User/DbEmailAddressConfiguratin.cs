using System;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения данных об адресах электронной почты дополнительной информации пользователя.
    /// </summary>
    public class DbEmailAddressConfiguration : EntityTypeConfiguration<DbEmailAddress>
    {
        public DbEmailAddressConfiguration()
        {
            ToTable("EmailAddresses")
                .HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasColumnName("Id");

            Property(t => t.Address)
                .IsRequired()
                .HasColumnName("Address")
                .HasMaxLength(Convert.ToInt32(Resources.MAXEMAILADDRESSLENGHT));
        }
    }
}