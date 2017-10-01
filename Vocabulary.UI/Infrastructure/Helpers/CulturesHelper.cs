using System;
using System.Collections.Generic;
using System.Linq;
using Vocabulary.Core.Infrastructure;

namespace Vocabulary.Infrastructure.Helpers
{
    public static class CulturesHelper
    {
        public static IEnumerable<Culture> GetAllCultures() => Enum.GetValues(typeof(Culture)).Cast<Culture>();
    }
}
