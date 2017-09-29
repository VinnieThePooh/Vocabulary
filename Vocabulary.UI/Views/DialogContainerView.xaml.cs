using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;
using Vocabulary.ViewModels;

namespace Vocabulary.Views
{
    /// <summary>
    /// Interaction logic for DialogContainerView.xaml
    /// </summary>
    public partial class DialogContainerView : Window
    {
        public DialogContainerView()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.DialogContainerViewModel;
            Closing += (s, e) =>
            {
                e.Cancel = true;
                Messenger.Default.Send(new HideUserControlMessage());
            };
        }
    }
}
