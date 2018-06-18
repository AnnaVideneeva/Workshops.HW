using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.DAL.Configurations
{
    /// <summary>
    /// Описание сущности ParserSettings
    /// </summary>
    public class ParserSettingsMap : EntityTypeConfiguration<ParserSettingsEntity>
    {
        public ParserSettingsMap()
        {
            ToTable("ParserSettings")
                .HasKey(p => p.Id);

            Property(p => p.BaseUrl)
                .IsRequired()
                .HasColumnName("BaseUrl")
                .HasMaxLength(250);

            Property(p => p.Prefix)
                .IsOptional()
                .HasColumnName("Prefix")
                .HasMaxLength(200);

            Property(p => p.StartPoint)
                .IsOptional()
                .HasColumnName("StartPoint");

            Property(p => p.EndPoint)
                .IsOptional()
                .HasColumnName("EndPoint");

            this.HasRequired<ResourceEntity>(p => p.Resource).WithMany(r => r.ParserSettings)
                .HasForeignKey<int>(p => p.ResourceId);
        }
    }
}
