using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;

namespace Vocabulary.Views
{
    /// <summary>
    /// Interaction logic for WordsListView.xaml
    /// </summary>
    public partial class WordsListView : UserControl
    {
        private DialogContainerView dialogContainerView;

        public WordsListView()
        {
            InitializeComponent();
            
            Loaded += (s, e) =>
            {
                dialogContainerView = new DialogContainerView();
            };

            Messenger.Default.Register<ShowUserControlMessage>(this, m => dialogContainerView.ShowDialog());
            Messenger.Default.Register<DialogResultOkMessage>(this, m =>
            {
                dialogContainerView.Hide();
                //dialogContainerView = null;
            });
            Messenger.Default.Register<DialogResultCancelMessage>(this, m =>
            {
                dialogContainerView.Hide();
                //dialogContainerView = null;
            });
        }
    }
}
