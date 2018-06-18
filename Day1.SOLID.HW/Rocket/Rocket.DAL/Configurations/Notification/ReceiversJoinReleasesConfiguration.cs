using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения сводных данных о получателе и релизе
    /// </summary>
    public class ReceiversJoinReleasesConfiguration : EntityTypeConfiguration<DbReceiversJoinReleases>
    {
        public ReceiversJoinReleasesConfiguration()
        {
            ToTable("ReceiversJoinReleases");

            HasKey(x => new { x.ReceiverId, x.ReleaseMessageId });

            Property(x => x.Viewed).IsRequired();
        }
    }
}