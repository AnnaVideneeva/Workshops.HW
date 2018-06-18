using Rocket.DAL.Common.DbModels.DbPersonalArea;
using System.Data.Entity.ModelConfiguration;

namespace Rocket.DAL.Configurations.PersonalArea
{
    public class DbUserProfileConfiguration : EntityTypeConfiguration<DbUserProfile>
    {
        public DbUserProfileConfiguration()
        {
            ToTable("UserProfile")
                .HasKey(p => p.DbUser_Id)
                .HasRequired(p => p.DbUser)
                .WithRequiredDependent(d => d.DbUserProfile);

            Property(p => p.Avatar)
                .IsOptional()
                .HasColumnName("AvatarPath")
                .IsUnicode()
                .HasMaxLength(200)
                .IsVariableLength();

            HasMany(p => p.Email)
                .WithRequired(e => e.DbUserProfile)
                .HasForeignKey(e => e.DbUserProfileId);

            HasMany(p => p.Genres)
                .WithMany(e => e.ListAuthorisedUser)
                .Map(m =>
                {
                    m.ToTable("UserProfileGenres")
                    .MapLeftKey("UserProfileId")
                    .MapRightKey("GenreId");
                });

            HasMany(p => p.MusicGenres)
                .WithMany(e => e.DbAuthorisedUsers)
                .Map(m =>
                {
                    m.ToTable("UserProfileMusicGenres")
                    .MapLeftKey("UserProfileId")
                    .MapRightKey("MusicGenreId");
                });
        }
    }
}