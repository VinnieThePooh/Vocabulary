using System.Data.Entity;
using Vocabulary.Core.Infrastructure;

namespace Vocabulary.Core.DataAccess
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
