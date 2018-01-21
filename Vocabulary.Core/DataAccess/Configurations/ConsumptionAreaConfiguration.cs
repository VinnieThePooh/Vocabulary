using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Configurations
{
   public class ConsumptionAreaConfiguration: EntityTypeConfiguration<ConsumptionArea>
    {
        public ConsumptionAreaConfiguration()
        {
            ToTable("ConsumptionAreas", SchemaNames.Handbooks);
            Property(x => x.AreaName)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute {IsUnique = true}));
            HasMany(x => x.Translations).WithOptional(x => x.ConsumptionArea).HasForeignKey(x => x.IdConsumptionArea); 
        }
    }
}
