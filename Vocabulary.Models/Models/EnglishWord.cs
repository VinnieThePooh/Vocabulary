using System.Collections.Generic;
using Vocabulary.Models.Infrastructure;

namespace Vocabulary.Models.Models
{
   public class EnglishWord
    {
        public EnglishWord()
        {
            Translations = new List<WordTranslation>();
        }

        public int EnglishWordId { get; set; }

        public string Text { get; set; }

        public Culture Culture { get; set; }

        public string Transcription { get; set; }

        public virtual List<WordTranslation> Translations { get; set; }
        public virtual List<EnglishWord> Synonyms { get; set; }
    }
}
