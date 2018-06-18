using System;
using Rocket.DAL.Common.DbModels.User;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения сведений о том, как обращаться к пользователю.
    /// </summary>
    public class DbHowToCallConfiguration : EntityTypeConfiguration<DbHowToCall>
    {
        public DbHowToCallConfiguration()
        {
            ToTable("HowToCalls")
                .HasKey(t => t.Id)
                .Property(t => t.Id)
                .HasColumnName("Id");

            Property(t => t.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(Convert.ToInt32(Resources.MAXHOWTOCALLLENGHT));
        }
    }
}