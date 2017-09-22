using System.Data.Entity.ModelConfiguration;
using Vocabulary.Models.Infrastructure;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Configurations
{
   public class UsagesSampleConfiguration: EntityTypeConfiguration<UsageSample>
    {
        public UsagesSampleConfiguration()
        {
            ToTable(TableNames.UsageSamples);
            Property(x => x.SampleText).HasMaxLength(300);
        }
    }
}
