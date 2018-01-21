using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Configurations
{
    public class EnglishWordConfiguration: EntityTypeConfiguration<EnglishWord>
    {
        public EnglishWordConfiguration()
        {
            ToTable(TableNames.Words);
            Property(x => x.Text)
                .HasMaxLength(200)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute {IsUnique = true}));
            HasMany(x => x.Translations).WithRequired(x => x.Word).HasForeignKey(x => x.IdWord);
            Property(x => x.Transcription).HasMaxLength(200);
            HasMany(x => x.Synonyms)
                .WithMany()
                .Map((m) =>
                {
                    m.ToTable("WordsToSynonyms");
                    m.MapLeftKey(nameof(EnglishWord.EnglishWordId));
                    m.MapRightKey("SynonymId");
                });
        }
    }
}
