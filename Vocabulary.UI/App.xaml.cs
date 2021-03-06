using System;
using System.Windows;
using MugenMvvmToolkit;
using MugenMvvmToolkit.WPF.Infrastructure;
using Vocabulary.Infrastructure;
using System.Configuration;
using System.Threading.Tasks;

namespace Vocabulary
{
    public partial class App : Application
    {

        Setup setup;

        public App()
        {            
            PathHelpers.EnsureDataDirectory();
            setup = new Setup(this);           


            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var t = e.Exception;
            var k = 0;
        }

        private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var ar = e.Exception;
            var t = 0;
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var k = e.ExceptionObject;
            var t = 0;
        }

       
    }
}