using System.Data.Entity.ModelConfiguration;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Configurations
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
