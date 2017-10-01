namespace Vocabulary.ViewModels.Abstract
{
    public interface IDialogNotifiableViewModel
    {
        void HandleDialogResultOk();
        void HandleDialogResultCancel();
    }
}
