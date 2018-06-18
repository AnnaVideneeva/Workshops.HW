using System;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.User;
using Rocket.DAL.Properties;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения информации о почтовых адресах дополнительной информации пользователей.
    /// </summary>
    public class DbAddressConfiguration : EntityTypeConfiguration<DbAddress>
    {
        public DbAddressConfiguration()
        {
            ToTable("Addresses")
                .HasKey(a => a.Id)
                .Property(a => a.Id)
                .HasColumnName("Id");

            HasOptional(ud => ud.Country)
                .WithMany(s => s.DbAddresses)
                .HasForeignKey(ud => ud.CountryId);

            Property(a => a.ZipCode)
                .IsOptional()
                .HasColumnName("ZipCode")
                .HasMaxLength(Convert.ToInt32(Resources.MAXZIPCODELENGHT));

            Property(a => a.City)
                .IsOptional()
                .HasColumnName("City")
                .HasMaxLength(Convert.ToInt32(Resources.MAXCITYLENGHT));

            Property(a => a.Building)
                .IsOptional()
                .HasColumnName("Building")
                .HasMaxLength(Convert.ToInt32(Resources.MAXBUILDINGLENGHT));

            Property(a => a.BuildingBlock)
                .IsOptional()
                .HasColumnName("BuildingBlock")
                .HasMaxLength(Convert.ToInt32(Resources.MAXBUILDINBLOCKGLENGHT));

            Property(a => a.Flat)
                .IsOptional()
                .HasColumnName("Flat")
                .HasMaxLength(Convert.ToInt32(Resources.MAXFLATGLENGHT));
        }
    }
}