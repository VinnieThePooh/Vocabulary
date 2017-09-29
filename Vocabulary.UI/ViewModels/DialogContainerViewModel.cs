using System;
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
            Messenger.Default.Register<ShowEditWordViewModel>(this, m =>
            {
                CurrentContent = ViewModelLocator.EditWordViewModel;
                DialogTitle = m.WindowTitle;
                ((EditWordViewModel)CurrentContent).CurrentWord = m.CurrentWord;
            });
            Messenger.Default.Register<ShowAddWordViewModel>(this, m =>
            {
                CurrentContent = ViewModelLocator.AddNewWordViewModel;
                DialogTitle = m.WindowTitle;
                ((AddNewWordViewModel)CurrentContent).CurrentWord = m.CurrentWord;
            });
        }

        public string DialogTitle { get; set; }

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
