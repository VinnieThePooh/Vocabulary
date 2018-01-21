using System.Collections.Generic;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Infrastructure.Helpers;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.ViewModels
{
    
   public class EditWordViewModel: EditableViewModel<EnglishWord>, IHasDisplayName
    {
        #region Constructors

        public EditWordViewModel(string displayName)
        {
            DisplayName = displayName;
            Cultures = CulturesHelper.GetAllCultures();
        }

        #endregion

        #region Properties

        public IEnumerable<Culture> Cultures { get;}

        #endregion

        public string DisplayName { get; }
    }
}
