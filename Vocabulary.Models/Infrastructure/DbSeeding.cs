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
             TrySeedFromFile(context);
        }


        private static void TrySeedFromFile(VocabularyContext context)
        {
            
        }
    }
}
