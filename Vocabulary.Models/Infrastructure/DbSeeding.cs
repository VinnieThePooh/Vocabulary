using System;
using System.Data.Entity;
using Vocabulary.Models.DataAccess;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.Infrastructure
{
    public static class DbSeeding
    {
        public static void SeedDatabase(VocabularyContext context)
        {
             if (context == null)
                 throw new ArgumentNullException(nameof(context));

            CorrectSchema(context);
            TrySeedFromFiles(context);
        }


        private static void TrySeedFromFiles(VocabularyContext context)
        {
            
        }


        private static void CorrectSchema(VocabularyContext context)
        {
            string constraintName = "dateDefaultConstraint";
            var sql = $"alter table {TableNames.Words} add constraint {constraintName} default getdate() for {nameof(EnglishWord.AdditionDate)}";
            context.Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction, sql);
        }
    }
}
