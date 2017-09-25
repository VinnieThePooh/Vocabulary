using System.Windows;
using GalaSoft.MvvmLight;
using Vocabulary.Models.DataAccess.Interfaces;

namespace Vocabulary.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        #region Fields

        
        private ViewModelBase dynamicViewModel;

        #endregion

        #region Constructor

        public MainViewModel(IEnglishWordRepository repository)
        {
            ExitCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window>(ExitFromApplication);
        }



        #endregion

        #region Properties


        public ViewModelBase DynamicViewModel
        {
            get { return dynamicViewModel; }
            set
            {
                if (value == dynamicViewModel)
                    return;
                dynamicViewModel = value;
                RaisePropertyChanged(nameof(DynamicViewModel));
            }
        }


        #region Commands

        public GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window> ExitCommand { get; }


        #endregion

        #endregion

        #region Implementation details

        private void ExitFromApplication(Window window) => window?.Close();

        #endregion
    }
}

        
    
