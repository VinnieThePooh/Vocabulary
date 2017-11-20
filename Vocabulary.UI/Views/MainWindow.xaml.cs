using System.Windows;
using MugenMvvmToolkit.Attributes;
using Vocabulary.Core.DataAccess;
using Vocabulary.ViewModels;

namespace Vocabulary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ViewModel(typeof(MainViewModel))]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
