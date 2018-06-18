using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Notification;

namespace Rocket.DAL.Configurations.Notification
{
    /// <summary>
    /// Конфигурация хранения данных о шаблоне email сообщения
    /// </summary>
    public class EmailTemplateConfiguration : EntityTypeConfiguration<DbEmailTemplate>
    {
        public EmailTemplateConfiguration()
        {
            ToTable("EmailTemplates");

            HasKey(x => x.Id);

            Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(50);

            Property(x => x.Body)
                .IsRequired()
                .HasColumnType("nvarchar(MAX)");
        }
    }
}