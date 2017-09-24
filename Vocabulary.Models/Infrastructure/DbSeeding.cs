using System;
using Vocabulary.Models.DataAccess;

namespace Vocabulary.Models.Infrastructure
{
    public static class DbSeeding
    {
        public static void SeedDatabase(VocabularyContext context)
        {
             if (context == null)
                 throw new ArgumentNullException(nameof(context));
             TrySeedFromFiles(context);
        }


        private static void TrySeedFromFiles(VocabularyContext context)
        {
            
        }
    }
}
