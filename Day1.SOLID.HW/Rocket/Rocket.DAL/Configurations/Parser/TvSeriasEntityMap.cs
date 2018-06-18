using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.DAL.Configurations.Parser
{
    public class TvSeriasEntityMap : EntityTypeConfiguration<TvSeriasEntity>
    {
        public TvSeriasEntityMap()
        {
            ToTable("TvSerias");

            Property(p => p.TitleRu)
                .IsRequired()
                .HasColumnName("TitleRu")
                .HasMaxLength(250);

            Property(p => p.TitleEn)
                .IsRequired()
                .HasColumnName("TitleEn")
                .HasMaxLength(250);

            Property(p => p.PosterImageUrl)
                .IsOptional()
                .HasColumnName("PosterImageUrl")
                .IsMaxLength();

            Property(p => p.LostfilmRate)
                .IsOptional()
                .HasColumnName("LostfilmRate");

            Property(p => p.RateImDb)
                .IsOptional()
                .HasColumnName("RateImDb");

            Property(p => p.UrlToOfficialSite)
                .IsOptional()
                .HasColumnName("UrlToOfficialSite")
                .IsMaxLength();

            Property(p => p.CurrentStatus)
                .IsOptional()
                .HasColumnName("CurrentStatus")
                .HasMaxLength(50);

            Property(p => p.TvSerialCanal)
                .IsOptional()
                .HasColumnName("TvSerialCanal")
                .HasMaxLength(150);

            Property(p => p.Summary)
                .IsOptional()
                .HasColumnName("Summary")
                .IsMaxLength();

            Property(p => p.UrlToSource)
                .IsOptional()
                .HasColumnName("UrlToSource")
                .IsMaxLength();

            Property(p => p.UrlToSource)
                .IsOptional()
                .HasColumnName("UrlToSource")
                .IsMaxLength();

            HasMany(f => f.ListPerson)
                .WithMany(p => p.ListTvSerias)
                .Map(m =>
                {
                    m.ToTable("TvSeriasToPersons");
                    m.MapLeftKey("TvSeriasId");
                    m.MapRightKey("PersonId");
                });

            HasMany(f => f.ListGenreEntity)
                .WithMany(p => p.ListTvSerias)
                .Map(m =>
                {
                    m.ToTable("TvSeriasToGenres");
                    m.MapLeftKey("TvSeriasId");
                    m.MapRightKey("GenreId");
                });

            ///// <summary>
            ///// Год начала показа сериала.
            ///// </summary>
            //public string TvSerialYearStart { get; set; }

            ///// <summary>
            ///// Дата премьеры прописью для последующего парсинга.
            ///// </summary>
            //public string PremiereDateForParse { get; set; }
        }
    }
}
