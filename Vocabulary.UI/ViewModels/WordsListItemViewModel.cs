using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Models;

namespace Vocabulary.ViewModels
{
    class WordsListItemViewModel:ItemViewModelBase
    {
        #region Constructors

        public WordsListItemViewModel()
        {
            ContentViewModel = GetViewModel<GridViewModel<EnglishWord>>();
        }

        #endregion

        
    }
}
