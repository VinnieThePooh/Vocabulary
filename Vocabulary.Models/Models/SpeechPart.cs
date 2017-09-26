using System.Collections.Generic;

namespace Vocabulary.Models.Models
{
    public class SpeechPart
    {
        public SpeechPart()
        {
            Translations = new List<WordTranslation>();
        }

        public int SpeechPartId { get; set; }

        public string SpeechPartName { get; set; }

        public virtual List<WordTranslation> Translations { get; set; }
    }
}
