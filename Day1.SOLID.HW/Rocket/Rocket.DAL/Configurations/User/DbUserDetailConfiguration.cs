using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.User;

namespace Rocket.DAL.Configurations.User
{
    /// <summary>
    /// Конфигурация хранения дополнительной информации о пользователях.
    /// </summary>
    public class DbUserDetailConfiguration : EntityTypeConfiguration<DbUserDetail>
    {
        public DbUserDetailConfiguration()
        {
            ToTable("UserDetails")
                .HasKey(ud => ud.Id)
                .Property(ud => ud.Id)
                .HasColumnName("Id");

            Property(ud => ud.ActivationNeeded)
                .IsOptional()
                .HasColumnName("ActivationNeeded");

            HasOptional(ud => ud.Sitizenship)
                .WithMany(s => s.DbUserDetails)
                .HasForeignKey(ud => ud.SitizenshipId);

            HasOptional(ud => ud.Language)
                .WithMany(l => l.DbUserDetails)
                .HasForeignKey(ud => ud.LanguageId);

            Property(ud => ud.DateOfBirth)
                .IsOptional()
                .HasColumnName("DateOfBirth");

            HasOptional(ud => ud.Gender)
                .WithMany(g => g.DbUserDetails)
                .HasForeignKey(ud => ud.GenderId);

            HasOptional(ud => ud.HowToCall)
                .WithMany(h => h.DbUserDetails)
                .HasForeignKey(ud => ud.HowToCallId);

            HasMany(ud => ud.PhoneNumbers)
                .WithMany(pn => pn.DbUserDetails)
                .Map(m =>
                {
                    m.ToTable("UserDetailsPhoneNumbers");
                    m.MapLeftKey("UserDetailId");
                    m.MapRightKey("PhoneNumberId");
                });

            HasMany(ud => ud.EMailAddresses)
                .WithMany(pn => pn.DbUserDetails)
                .Map(m =>
                {
                    m.ToTable("UserDetailsEmailAddresses");
                    m.MapLeftKey("UserDetailId");
                    m.MapRightKey("EmailAddressId");
                });

            HasOptional(ud => ud.MailAddress)
                .WithRequired(ud => ud.DbUserDetail);
        }
    }
}