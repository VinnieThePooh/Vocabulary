using System.Windows.Controls;
using MugenMvvmToolkit.Attributes;
using Vocabulary.Core.ViewModels;

namespace Vocabulary.Views
{
    /// <summary>
    /// Interaction logic for WordsListView.xaml
    /// </summary>
    [ViewModel(typeof(WordsListViewModel))]
    public partial class WordsListView : UserControl
    {
        public WordsListView()
        {
            InitializeComponent();
        }
    }
}
