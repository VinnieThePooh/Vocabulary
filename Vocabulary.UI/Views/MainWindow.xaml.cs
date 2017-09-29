using System.Windows;
using Vocabulary.Models.DataAccess;
using Vocabulary.ViewModels;

namespace Vocabulary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Closing += (s, e) =>
            {
                ViewModelLocator.Cleanup();
            };

            var context = new VocabularyContext();
            context.Database.Initialize(false);
        }
    }
}
