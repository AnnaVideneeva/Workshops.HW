using Rocket.DAL.Common.DbModels.DbPersonalArea;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.PersonalArea
{
    public class DbGenreConfiguration : EntityTypeConfiguration<DbGenre>
    {
        public DbGenreConfiguration()
        {
            ToTable("Genres")
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasColumnName("Id");

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(30)
                .IsVariableLength()
                .HasColumnName("Name");

            Property(p => p.DbCategoryId)
                .HasColumnName("CategoryId");
        }
    }
}