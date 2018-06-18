using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.ReleaseList
{
    /// <summary>
    /// Конфигурация хранения данных о музыкальных исполнителях
    /// </summary>
    public class DbMusicianConfiguration : EntityTypeConfiguration<DbMusician>
    {
        public DbMusicianConfiguration()
        {
            ToTable("Musician");

            Property(c => c.FullName)
                .IsRequired()
                .HasColumnName("FullName");
        }
    }
}