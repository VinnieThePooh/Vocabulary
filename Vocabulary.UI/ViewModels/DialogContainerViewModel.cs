using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;
using Vocabulary.ViewModels.Abstract;

namespace Vocabulary.ViewModels
{
   public class DialogContainerViewModel: ViewModelBase
    {
        private NotifiableViewModelBase currentContent;
        private string dialogTitle;

        public DialogContainerViewModel()
        {
            RegisterToMessages();   
            DialogResultOkCommand = new RelayCommand(MakeDialogToBeOk);
            DialogResultCancelCommand = new RelayCommand(MakeDialogToBeCancel);
        }

        public RelayCommand DialogResultOkCommand { get; }

        public RelayCommand DialogResultCancelCommand { get; }

        public string DialogTitle
        {
            get => dialogTitle;
            set
            {
                dialogTitle = value;
                RaisePropertyChanged();
            }
        }

        public NotifiableViewModelBase CurrentContent
        {
            get => currentContent;
            set
            {
                currentContent = value;
                RaisePropertyChanged();

                if (currentContent != null)
                {
                    Messenger.Default.Send(new ShowUserControlMessage());
                }
            }
        }


        #region Implementation details

        private void RegisterToMessages()
        {
            Messenger.Default.Register<ShowEditWordViewModelMessage>(this, m =>
            {
                DialogTitle = m.WindowTitle;
                var editVm = ViewModelLocator.EditWordViewModel;
                editVm.SaveOriginalWord(m.CurrentWord);
                editVm.CurrentWord = m.CurrentWord;
                CurrentContent = editVm;
            });
            Messenger.Default.Register<ShowAddWordViewModelMessage>(this, m =>
            {
                DialogTitle = m.WindowTitle;
                var content = ViewModelLocator.AddNewWordViewModel;
                content.CurrentWord = m.CurrentWord;
                CurrentContent = content;
            });
        }

        private void MakeDialogToBeOk()
        {
            CurrentContent.HandleDialogResultOk();
            Messenger.Default.Send(new DialogResultOkMessage());
        }
        
        private void MakeDialogToBeCancel()
        {
            CurrentContent.HandleDialogResultCancel();
            Messenger.Default.Send(new DialogResultCancelMessage());
        }

        #endregion
    }
}
