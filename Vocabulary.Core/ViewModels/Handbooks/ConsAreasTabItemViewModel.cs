using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Models;
using Vocabulary.Core.ViewModels.Abstract;

namespace Vocabulary.Core.ViewModels.Handbooks
{
    public class ConsAreasTabItemViewModel: TabItemViewModelBase
    {
        #region Constructors

        public ConsAreasTabItemViewModel()
        {
            ContentViewModel = GetViewModel<GridViewModel<ConsumptionArea>>();
        }

        public ConsAreasTabItemViewModel(string displayName) : base(displayName)
        {
            ContentViewModel = GetViewModel<GridViewModel<ConsumptionArea>>();
        }

        #endregion


        public override ViewModelBase ContentViewModel { get; set; }
    }
}
