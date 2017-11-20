using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace Vocabulary
{
    public partial class App : Application
    {
        public App()
        {
            // ReSharper disable once ObjectCreationAsStatement
            var container = new MugenContainer();
            InitBindings(container);
            new Bootstrapper<MugenApp>(this, container);
        }


        private void InitBindings(MugenContainer mugenContainer)
        {
            //mugenContainer.Bind<>();
        }
    }
}