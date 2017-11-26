using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Models;
using Vocabulary.Core.ViewModels.Abstract;

namespace Vocabulary.Core.ViewModels
{
    class WordsListTabItemViewModel:TabItemViewModelBase
    {
        #region Constructors

        public WordsListTabItemViewModel()
        {
            ContentViewModel = GetViewModel<GridViewModel<EnglishWord>>();
        }

        public WordsListTabItemViewModel(string displayName):base(displayName)
        {
            ContentViewModel = GetViewModel<GridViewModel<EnglishWord>>();
        }

        #endregion

        #region Properties

        public override ViewModelBase ContentViewModel { get; set; }

        #endregion
    }
}
