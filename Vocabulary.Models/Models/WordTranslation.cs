﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Vocabulary.Models.Models
{
   public class WordTranslation
    {
        #region EF related

        public int WordTranslationId { get; set; }

        public int IdWord { get; set; }

        [ForeignKey(nameof(IdWord))]
        public virtual EnglishWord Word { get; set; }

        public virtual UsageSample UsageSample { get; set; }

        #endregion

        #region Payload

        public int TranslationPriority { get; set; }

        public string Text { get; set; }

        #endregion
    }
}