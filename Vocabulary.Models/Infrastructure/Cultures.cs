using System.ComponentModel.DataAnnotations;

namespace Vocabulary.Core.Infrastructure    
{
    public enum Culture
    {
        [Display(Name="British")]
        British=0,
        [Display(Name="USA")]
        American=1
    }
}
