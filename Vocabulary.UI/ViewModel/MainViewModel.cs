using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;
using System.Threading.Tasks;

namespace Vocabulary.ViewModel
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

        #region Fields private 

        readonly IEnglishWordRepository wordsRepository;

        private ObservableCollection<EnglishWord> englishWords;

        #endregion

        public MainViewModel(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            
        }


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
    }
}