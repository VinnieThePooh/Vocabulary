using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Configurations
{
    public class SpeechPartConfiguration: EntityTypeConfiguration<SpeechPart>
    {
        public SpeechPartConfiguration()
        {
            ToTable(TableNames.SpeechParts, SchemaNames.Handbooks);
            HasMany(x => x.Translations).WithOptional(x => x.PartOfSpeech).HasForeignKey(x => x.IdPartOfSpeech);
            Property(x => x.SpeechPartName)
                .HasMaxLength(100)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,new IndexAnnotation(new IndexAttribute {IsUnique = true}));
        }
    }
}
