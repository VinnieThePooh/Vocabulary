using System.ComponentModel.DataAnnotations.Schema;

namespace Vocabulary.Core.Models
{
   public class UsageSample
    {
        #region EF related

        public int UsageSampleId { get; set; }

        [ForeignKey(nameof(UsageSampleId))]
        public virtual WordTranslation Translation { get; set; }

        #endregion

        #region Payload

        public string SampleText { get; set; }

        public string SampleTranslation { get; set; }

        // especially redundant
        public string ParentWordTranslation { get; set; }

        #endregion
    }
}
