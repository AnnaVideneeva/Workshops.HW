using Rocket.DAL.Common.DbModels.Parser;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.Parser
{
    public class EpisodeEntityMap : EntityTypeConfiguration<EpisodeEntity>
    {
        public EpisodeEntityMap()
        {
            ToTable("Episode");

            Property(p => p.ReleaseDateRu)
                .IsOptional()
                .HasColumnName("ReleaseDateRu");

            Property(p => p.ReleaseDateEn)
                .IsOptional()
                .HasColumnName("ReleaseDateEn");

            Property(p => p.Number)
                .IsRequired()
                .HasColumnName("Number");

            Property(p => p.TitleRu)
                .IsRequired()
                .HasColumnName("TitleRu")
                .HasMaxLength(250);

            Property(p => p.TitleEn)
                .IsRequired()
                .HasColumnName("TitleEn")
                .HasMaxLength(250);

            Property(p => p.DurationInMinutes)
                .IsOptional()
                .HasColumnName("DurationInMinutes");

            Property(p => p.UrlForEpisodeSource)
                .IsRequired()
                .HasColumnName("UrlForEpisodeSource")
                .IsMaxLength();

            Property(p => p.SeasonId)
                .IsRequired()
                .HasColumnName("SeasonId");

            HasRequired(p => p.Season)
                .WithMany(r => r.ListEpisode)
                .HasForeignKey(p => p.SeasonId);
        }
    }
}
