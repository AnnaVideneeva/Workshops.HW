using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Parser;
using Rocket.DAL.Common.DbModels.ReleaseList;

namespace Rocket.DAL.Configurations
{
    /// <summary>
    /// Описание сущности ResourceItemEntity
    /// </summary>
    public class ResourceItemMap : EntityTypeConfiguration<ResourceItemEntity>
    {
        public ResourceItemMap()
        {
            ToTable("ResourceItem")
                .HasKey(p => p.Id);

            Property(p => p.ResourceId)
                .IsRequired()
                .HasColumnName("ResourceId");

            Property(p => p.ResourceInternalId)
                .IsRequired()
                .HasColumnName("ResourceInternalId")
                .HasMaxLength(50);

            Property(p => p.CreatedDateTime)
                .IsRequired()
                .HasColumnName("CreatedDateTime")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(p => p.LastModified)
                .IsRequired()
                .HasColumnName("LastModified")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);

            Property(p => p.MusicId)
                .IsRequired()
                .HasColumnName("MusicId");

            this.HasRequired<ResourceEntity>(p => p.Resource).WithMany(r => r.ResourceItems)
                .HasForeignKey<int>(p => p.ResourceId);

            this.HasRequired<DbMusic>(p => p.Music).WithMany(r => r.ResourceItems)
                .HasForeignKey<int>(p => p.MusicId);
        }
    }
}
