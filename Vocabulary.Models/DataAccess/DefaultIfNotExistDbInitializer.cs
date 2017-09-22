using System.Data.Entity;
using Vocabulary.Models.Infrastructure;

namespace Vocabulary.Models.DataAccess
{
    public class DefaultIfNotExistDbInitializer: CreateDatabaseIfNotExists<VocabularyContext>
    {
        protected override void Seed(VocabularyContext context)
        {
            base.Seed(context);
            DbSeeding.SeedDatabase(context);
        }
    }
}
