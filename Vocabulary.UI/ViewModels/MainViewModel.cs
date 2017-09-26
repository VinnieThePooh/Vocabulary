using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using Vocabulary.ViewModel;

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

        private ViewModelBase wordsListViewModel;

        #endregion

        #region Constructor

        public MainViewModel()
        {
            ExitCommand = new RelayCommand<Window>(ExitFromApplication);
            ChangeViewModelCommand = new RelayCommand<ViewModelBase>(ChangeViewModel);
        }



        #endregion

        #region Properties


        public ViewModelBase DynamicViewModel
        {
            get => dynamicViewModel;
            set
            {
                if (value == dynamicViewModel)
                    return;
                dynamicViewModel = value;
                RaisePropertyChanged();
            }
        }


        #region Commands

        public RelayCommand<Window> ExitCommand { get; }

        public RelayCommand<ViewModelBase> ChangeViewModelCommand { get; }


        #endregion


        #region ViewModels

        public ViewModelBase WordsListViewModel => wordsListViewModel ??
                                                   (wordsListViewModel =
                                                    ServiceLocator.Current.GetInstance<WordsListViewModel>());
        

        #endregion



        #endregion

        #region Implementation details

        private void ExitFromApplication(Window window) => window?.Close();

        private void ChangeViewModel(ViewModelBase newViewModel)
        {
            if (newViewModel != null)
                DynamicViewModel = newViewModel;
        }


        #endregion
    }
}

        
    
