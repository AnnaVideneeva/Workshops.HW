using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения данных по сообщению о релизе
    /// </summary>
    public class ReleaseMessageConfiguration : EntityTypeConfiguration<DbReleaseMessage>
    {
        public ReleaseMessageConfiguration()
        {
            ToTable("ReleaseMessages");

            HasKey(x => x.Id);

            Property(x => x.ReleaseId).IsRequired();

            Property(x => x.ReleaseType).IsRequired();

            HasMany(x => x.ReceiversJoinReleases)
                .WithRequired(x => x.ReleaseMessage)
                .HasForeignKey(x => x.ReleaseMessageId);

            Property(x => x.ReleaseDate).IsRequired();

            Property(x => x.CreationTime).IsRequired();
        }
    }
}