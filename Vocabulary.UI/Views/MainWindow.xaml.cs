using System.Windows;
using MugenMvvmToolkit.Attributes;
using Vocabulary.Core.ViewModels;

namespace Vocabulary.Views
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
