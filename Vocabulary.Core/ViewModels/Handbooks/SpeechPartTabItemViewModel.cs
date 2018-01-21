using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Models;
using Vocabulary.Core.ViewModels.Abstract;

namespace Vocabulary.Core.ViewModels.Handbooks
{
   public class SpeechPartTabItemViewModel: TabItemViewModelBase
    {
        public SpeechPartTabItemViewModel()
        {
            ContentViewModel = GetViewModel<GridViewModel<SpeechPart>>();
        }

        public override ViewModelBase ContentViewModel { get; set; }
    }
}
