using Rocket.DAL.Common.DbModels.ReleaseList;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.ReleaseList
{
    /// <summary>
    /// Конфигурация хранения данных о музыкальном релизе
    /// </summary>
    public class DbMusicConfiguration : EntityTypeConfiguration<DbMusic>
    {
        public DbMusicConfiguration()
        {
            ToTable("Music");

            Property(f => f.PosterImagePath)
                .IsOptional()
                .HasColumnName("PosterImagePath")
                .HasMaxLength(200);

            Property(f => f.Duration)
                .IsOptional()
                .HasColumnName("Duration");

            Property(f => f.PosterImageUrl)
                .IsOptional()
                .HasColumnName("PosterImageUrl");

            HasMany(f => f.Musicians)
                .WithMany(p => p.Musics)
                .Map(m =>
                {
                    m.ToTable("MusicMusicians");
                    m.MapLeftKey("MusicId");
                    m.MapRightKey("MusiciansId");
                });

            HasMany(f => f.Genres)
                .WithMany(p => p.DbMusics)
                .Map(m =>
                {
                    m.ToTable("MusicReleaseGenres");
                    m.MapLeftKey("MusicId");
                    m.MapRightKey("MusicGenreId");
                });

            HasMany(f => f.MusicTracks)
                .WithRequired(p => p.DbMusic)
                .HasForeignKey(p => p.DbMusicId);
        }
    }
}