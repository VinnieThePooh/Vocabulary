using MugenMvvmToolkit.ViewModels;

namespace Vocabulary.ViewModels
{
    // todo: check it later
    public class HandBooksViewModel: ItemViewModelBase
    {
        public HandBooksViewModel()
        {
            // multiple grids may be here
            ContentViewModel = GetViewModel<MultiViewModel<ViewModelBase>>();
        }
    }
}
