using System;
using Rocket.DAL.Common.DbModels.User;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения данных о языках дополнительной информации пользователя.
    /// </summary>
    public class DbLanguageConfiguration : EntityTypeConfiguration<DbLanguage>
    {
        public DbLanguageConfiguration()
        {
            ToTable("Languages")
                .HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasColumnName("Id");

            Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(Convert.ToInt32(Resources.MAXLANGUAGELENGHT));
        }
    }
}