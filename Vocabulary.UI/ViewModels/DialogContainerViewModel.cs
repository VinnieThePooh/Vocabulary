using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Vocabulary.Infrastructure.Dialogs;

namespace Vocabulary.ViewModels
{
   public class DialogContainerViewModel: ViewModelBase
    {
        private ViewModelBase currentContent;

        public DialogContainerViewModel()
        {
            Messenger.Default.Register<ShowEditWordViewModel>(this, m => CurrentContent = ViewModelLocator.EditWordViewModel);
            Messenger.Default.Register<ShowAddWordViewModel>(this, m => CurrentContent = ViewModelLocator.AddNewWordViewModel);
        }

        public ViewModelBase CurrentContent
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
    }
}
