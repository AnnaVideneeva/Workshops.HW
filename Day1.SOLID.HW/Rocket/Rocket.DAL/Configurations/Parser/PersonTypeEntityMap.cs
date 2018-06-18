using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Rocket.DAL.Common.DbModels.Parser;

namespace Rocket.DAL.Configurations.Parser
{
    public class PersonTypeEntityMap : EntityTypeConfiguration<PersonTypeEntity>
    {
        public PersonTypeEntityMap()
        {
            ToTable("PersonType")
                .HasKey(p => p.Code);

            Property(t => t.Code)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(p => p.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasMaxLength(250);
        }
    }
}
