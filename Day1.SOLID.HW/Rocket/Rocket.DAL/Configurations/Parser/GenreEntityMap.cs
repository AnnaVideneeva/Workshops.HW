using Rocket.DAL.Common.DbModels.Parser;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.Parser
{
    public class GenreEntityMap : EntityTypeConfiguration<GenreEntity>
    {
        public GenreEntityMap()
        {
            ToTable("Genre");

            Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(250);

            Property(p => p.CategoryCode)
                .IsRequired()
                .HasColumnName("CategoryCode");

            HasRequired(p => p.Category)
                .WithMany(r => r.ListGenre)
                .HasForeignKey(p => p.CategoryCode);
        }
    }
}
