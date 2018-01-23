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

        private string displayName;

        #region Constructors

        public EditWordViewModel()
        {
            Cultures = CulturesHelper.GetAllCultures();
        }

        public EditWordViewModel(string dName):this()
        {
            displayName = dName;
        }

        #endregion

        #region Properties

        public IEnumerable<Culture> Cultures { get;}

        #endregion

        public string DisplayName
        {
            get { return displayName; }
        }
    }
}
