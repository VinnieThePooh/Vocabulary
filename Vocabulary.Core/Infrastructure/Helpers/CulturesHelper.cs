using System;
using System.Collections.Generic;
using System.Linq;

namespace Vocabulary.Core.Infrastructure.Helpers
{
    public static class CulturesHelper
    {
        public static IEnumerable<Culture> GetAllCultures() => Enum.GetValues(typeof(Culture)).Cast<Culture>();
    }
}
