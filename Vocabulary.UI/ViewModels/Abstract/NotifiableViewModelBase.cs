using GalaSoft.MvvmLight;

namespace Vocabulary.ViewModels.Abstract
{
    public abstract class NotifiableViewModelBase: ViewModelBase
    {
        public abstract void HandleDialogResultOk();
        public abstract void HandleDialogResultCancel();
    }
}
