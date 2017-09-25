using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.ViewModels
{
   public class WordsListViewModel: ViewModelBase
    {
        readonly IEnglishWordRepository wordsRepository;

        private ObservableCollection<EnglishWord> englishWords;


        public WordsListViewModel(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            AddNewWordCommand = new RelayCommand(AddNewWord);
            EditWordCommand = new RelayCommand<EnglishWord>(EditWord, w => CurrentWord != null);
            AddSynonymCommand = new RelayCommand<EnglishWord>(AddSynonym, w => CurrentWord != null);
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


        public EnglishWord CurrentWord { get; set; }
        
        public RelayCommand AddNewWordCommand { get; set; }
        public RelayCommand<EnglishWord> EditWordCommand { get; set; }
        public RelayCommand<EnglishWord> AddSynonymCommand { get; set; }


        private void AddNewWord()
        {
            
        }


        private void EditWord(EnglishWord currentWord)
        {
            
        }

        private void AddSynonym(EnglishWord currentWord)
        {

        }
    }
}
