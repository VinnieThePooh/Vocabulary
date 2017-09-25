using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
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

            CorrectWordsTableSchema(context);
            SeedConsumptionAreas(context);
            TrySeedWordsFromFiles(context);
        }


        private static void TrySeedWordsFromFiles(VocabularyContext context)
        {
                
        }

        private static void CorrectWordsTableSchema(VocabularyContext context)
        {
            string constraintName = "dateDF";
            var sql = $"alter table {TableNames.Words} add constraint {constraintName} default getdate() for {nameof(EnglishWord.AdditionDate)}";
            context.Database.ExecuteSqlCommand(TransactionalBehavior.EnsureTransaction, sql);
        }


        private static void SeedConsumptionAreas(VocabularyContext context)
        {
            context.Set<ConsumptionArea>()
                .AddOrUpdate(GetConsumptionAreas()
                .Select(ca => new ConsumptionArea{AreaName = ca})
                .ToArray());
        }


        private static IEnumerable<string> GetConsumptionAreas()
        {
            return new[] {"Common speech",
                          "British slang",
                          "American slang",
                          "Mathematics",
                           "Physics",
                           "Informatics",
                           "Idioma"};
        }
    }
}
