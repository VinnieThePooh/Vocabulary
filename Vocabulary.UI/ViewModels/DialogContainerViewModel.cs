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
            MessengerInstance.Register<ShowEditWordViewModel>(this, m => CurrentContent = ServiceLocator.Current.GetInstance<EditWordViewModel>());
            MessengerInstance.Register<ShowAddWordViewModel>(this, m => CurrentContent = ServiceLocator.Current.GetInstance<AddNewWordViewModel>());
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
