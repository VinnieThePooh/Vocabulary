using System.Data.Entity;
using System.Windows;
using Vocabulary.Infrastructure.Helpers;
using Vocabulary.Models.DataAccess;
using static Vocabulary.Infrastructure.Helpers.InitializationHelper;

namespace Vocabulary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetDataDirectoryFolder();
            EnsureDataDirectoryExists();
            Database.SetInitializer(new DefaultIfNotExistDbInitializer());
        }
    }
}
