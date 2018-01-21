using System.Data.Entity.ModelConfiguration;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Configurations
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
