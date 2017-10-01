using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Vocabulary.Core.DataAccess;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.Infrastructure
{
    public static class DbSeeding
    {
        public static void SeedDatabase(VocabularyContext context)
        {
             if (context == null)
                 throw new ArgumentNullException(nameof(context));

            CorrectWordsTableSchema(context);
            SeedConsumptionAreas(context);
            SeedSpeechOfParts(context);
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

        private static void SeedSpeechOfParts(VocabularyContext context)
        {
            context.Set<SpeechPart>()
                .AddOrUpdate(
                    new SpeechPart {SpeechPartName = SpeechPartNames.Noun},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Adjective},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Verb},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Pronoun },
                    new SpeechPart {SpeechPartName = SpeechPartNames.Adverb},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Union},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Particle},
                    new SpeechPart {SpeechPartName = SpeechPartNames.Preposition});
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
