using GalaSoft.MvvmLight;

namespace Vocabulary.ViewModels
{
    public abstract class NotifiableViewModelBase: ViewModelBase
    {
        public abstract void HandleDialogResultOk();
        public abstract void HandleDialogResultCancel();
    }
}
