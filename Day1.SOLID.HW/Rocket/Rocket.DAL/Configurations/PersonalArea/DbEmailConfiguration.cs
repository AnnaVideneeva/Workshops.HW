using Rocket.DAL.Common.DbModels.DbPersonalArea;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.PersonalArea
{
    public class DbEmailConfiguration : EntityTypeConfiguration<DbEmail>
    {
        public DbEmailConfiguration()
        {
            ToTable("Emails")
                .HasKey(k => k.Id)
                .Property(p => p.Id)
                .HasColumnName("Id");

            Property(p => p.Name)
                .IsRequired()
                .IsUnicode()
                .HasMaxLength(80)
                .IsVariableLength()
                .HasColumnName("Name");

            Property(p => p.DbUserProfileId)
                .IsRequired()
                .HasColumnName("UserProfileId");
        }
    }
}