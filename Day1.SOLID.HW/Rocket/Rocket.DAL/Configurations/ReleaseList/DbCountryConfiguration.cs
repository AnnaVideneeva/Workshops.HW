using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.DAL.Configurations.ReleaseList
{
    /// <summary>
    /// Конфигурация хранения данных о странах
    /// </summary>
    public class DbCountryConfiguration : EntityTypeConfiguration<DbCountry>
    {
        public DbCountryConfiguration()
        {
            ToTable("Countries")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("Id");

            Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(50);
        }
    }
}