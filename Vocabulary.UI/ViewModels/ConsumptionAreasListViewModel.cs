using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Vocabulary.Models.Models;

namespace Vocabulary.ViewModels
{
    public class ConsumptionAreasListViewModel: ViewModelBase
    {
        public ConsumptionAreasListViewModel()
        {
            Areas = new ObservableCollection<ConsumptionArea>();
        }

        public ObservableCollection<ConsumptionArea> Areas { get;}

        public ConsumptionArea Seleclted { get; set; }
    }
}
