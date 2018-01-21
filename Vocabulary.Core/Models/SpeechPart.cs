using System.Collections.Generic;

namespace Vocabulary.Core.Models
{
    public class SpeechPart
    {
        public SpeechPart()
        {
            Words = new List<EnglishWord>();
        }

        public int SpeechPartId { get; set; }

        public string SpeechPartName { get; set; }

        public virtual List<EnglishWord> Words { get; set; }
    }
}
