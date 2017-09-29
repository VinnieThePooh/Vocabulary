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

        public DialogContainerViewModel()
        {
            RegisterToMessages();   
            DialogResultOkCommand = new RelayCommand(MakeDialogToBeOk);
            DialogResultCancelCommand = new RelayCommand(MakeDialogToBeCancel);
        }

        public RelayCommand DialogResultOkCommand { get; }

        public RelayCommand DialogResultCancelCommand { get; }

        public string DialogTitle { get; set; }

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
            Messenger.Default.Register<ShowEditWordViewModel>(this, m =>
            {
                DialogTitle = m.WindowTitle;
                CurrentContent = ViewModelLocator.EditWordViewModel;
                var editVm = (EditWordViewModel)CurrentContent;
                editVm.SaveOrigin(m.CurrentWord);
                editVm.CurrentWord = m.CurrentWord;
                editVm.SelectedCulture =
                    editVm.Cultures.SingleOrDefault(c => c.ValueMember.Equals(m.CurrentWord?.Culture)) ??
                    editVm.Cultures.First();
            });
            Messenger.Default.Register<ShowAddWordViewModel>(this, m =>
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
