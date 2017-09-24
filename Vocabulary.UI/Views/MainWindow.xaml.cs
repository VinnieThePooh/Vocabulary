using System.Windows;
using Vocabulary.Models.DataAccess;

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
            var context = new VocabularyContext();
            context.Database.Initialize(false);
        }
    }
}
