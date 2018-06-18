using System;
using Rocket.DAL.Common.DbModels.User;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения данных о телефонных номерах дополнительной информации пользователя.
    /// </summary>
    public class DbPhoneNumberConfiguration : EntityTypeConfiguration<DbPhoneNumber>
    {
        public DbPhoneNumberConfiguration()
        {
            ToTable("PhoneNumbers")
                .HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasColumnName("Id");

            Property(t => t.Number)
                .IsRequired()
                .HasColumnName("Number")
                .HasMaxLength(Convert.ToInt32(Resources.MAXPHONENUMBERLENGHT));
        }
    }
}