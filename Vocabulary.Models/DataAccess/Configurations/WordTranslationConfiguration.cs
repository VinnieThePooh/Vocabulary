using System.Data.Entity.ModelConfiguration;
using Vocabulary.Models.Infrastructure;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Configurations
{
    public class WordTranslationConfiguration: EntityTypeConfiguration<WordTranslation>
    {
        public WordTranslationConfiguration()
        {
            ToTable(TableNames.Translations);
            HasOptional(x => x.UsageSample).WithRequired(x => x.Translation);
            Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
