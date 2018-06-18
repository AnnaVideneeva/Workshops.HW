using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.DAL.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// Описание сущности Resource
    /// </summary>
    public class ResourceMap : EntityTypeConfiguration<ResourceEntity>
    {
        public ResourceMap()
        {
            ToTable("Resource")
                .HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(50);

            Property(p => p.ResourceLink)
                .IsRequired()
                .HasColumnName("ResourceLink")
                .HasMaxLength(150);

            Property(p => p.ParseIsSwitchOn)
                .IsRequired()
                .HasColumnName("ParseIsSwitchOn");

            Property(p => p.ParsePeriodInMinutes)
                .IsRequired()
                .HasColumnName("ParsePeriodInMinutes");
        }
    }
}
