using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.ReleaseList
{
    /// <summary>
    /// Конфигурация хранения данных о музыкальных жанрах
    /// </summary>
    public class DbMusicGenreConfiguration : EntityTypeConfiguration<DbMusicGenre>
    {
        public DbMusicGenreConfiguration()
        {
            ToTable("MusicGenres");

            Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(50);
        }
    }
}