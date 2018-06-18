using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.ReleaseList
{
    /// <summary>
    /// Конфигурация хранения данных о релизах
    /// </summary>
    public class DbBaseReleaseConfiguration : EntityTypeConfiguration<DbBaseRelease>
    {
        public DbBaseReleaseConfiguration()
        {
            ToTable("Releases")
                .HasKey(f => f.Id)
                .Property(f => f.Id)
                .HasColumnName("Id");

            Property(f => f.ReleaseDate)
                .IsRequired()
                .HasColumnName("ReleaseDate");

            Property(f => f.Title)
                .IsRequired()
                .HasColumnName("Title")
                .HasMaxLength(50);
        }
    }
}