using System;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения данных о статусе пользователя.
    /// </summary>
    public class DbAccountStatusConfiguration : EntityTypeConfiguration<DbAccountStatus>
    {
        public DbAccountStatusConfiguration()
        {
            ToTable("AccountStatuses")
                .HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasColumnName("Id");

            Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(Convert.ToInt32(Resources.MAXACCOUNTSTATUSLENGHT));
        }
    }
}