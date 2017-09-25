using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

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

        readonly IEnglishWordRepository wordsRepository;

        private ObservableCollection<EnglishWord> englishWords;

        #endregion

        #region Constructor

        public MainViewModel(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            ExitCommand = new GalaSoft.MvvmLight.CommandWpf.RelayCommand<Window>(ExitFromApplication);
        }



        #endregion

        #region Properties

        public ObservableCollection<EnglishWord> EnglishWords
        {
            get
            {
                if (englishWords == null)
                    englishWords = wordsRepository.GetAllWords();
                return englishWords;
            }

            set
            {
                englishWords = value;
                RaisePropertyChanged(nameof(EnglishWords));
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

        
    
