using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Vocabulary.Models.Models
{
   public class WordTranslation
    {
        #region EF related

        public int WordTranslationId { get; set; }

        public int IdWord { get; set; }

        public int? IdConsumptionArea { get; set; }

        public int? IdPartOfSpeech { get; set; }

        [ForeignKey(nameof(IdWord))]
        public virtual EnglishWord Word { get; set; }

        public virtual UsageSample UsageSample { get; set; }

        [ForeignKey(nameof(IdConsumptionArea))]
        public virtual ConsumptionArea ConsumptionArea { get; set; }

        [ForeignKey(nameof(IdPartOfSpeech))]
        public virtual SpeechPart PartOfSpeech { get; set; }

        #endregion

        #region Payload

        public int TranslationPriority { get; set; }

        public string Text { get; set; }

        #endregion
    }
}
