using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Models;
using Vocabulary.Core.ViewModels.Abstract;

namespace Vocabulary.Core.ViewModels
{
    class WordsListTabItemViewModel:TabItemViewModelBase
    {
        private ViewModelBase _contentViewModel;

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

        public override ViewModelBase ContentViewModel
        {
            get => _contentViewModel;
            set
            {
                if (_contentViewModel == value)
                    return;
                _contentViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
