using System.Data.Entity;
using Vocabulary.Core.DataAccess.Configurations;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess
{
   public class VocabularyContext: DbContext
    {
        public VocabularyContext():base("VocabularyContext")
        {
            Words = Set<EnglishWord>();
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<EnglishWord> Words { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new EnglishWordConfiguration());
            modelBuilder.Configurations.Add(new WordTranslationConfiguration());
            modelBuilder.Configurations.Add(new UsagesSampleConfiguration());
            modelBuilder.Configurations.Add(new ConsumptionAreaConfiguration());
            modelBuilder.Configurations.Add(new SpeechPartConfiguration());
        }
    }
}
