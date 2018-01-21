using System.Collections.Generic;

namespace Vocabulary.Core.Models
{
   public class ConsumptionArea
    {
        public ConsumptionArea()
        {
            Translations = new List<WordTranslation>();
        }

        public int ConsumptionAreaId { get; set; }

        public string AreaName { get; set; }

        public virtual List<WordTranslation> Translations { get; set; }
    }
}
