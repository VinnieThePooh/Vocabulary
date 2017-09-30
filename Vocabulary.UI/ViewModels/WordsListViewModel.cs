using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.ViewModels
{
   public class WordsListViewModel: ViewModelBase
    {
        readonly IEnglishWordRepository wordsRepository;

        private ObservableCollection<EnglishWord> englishWords;
        private EnglishWord currentWord;


        public WordsListViewModel(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            AddNewWordCommand = new RelayCommand(AddNewWord);
            EditWordCommand = new RelayCommand<EnglishWord>(EditWord, w => w != null);
            AddSynonymCommand = new RelayCommand<EnglishWord>(AddSynonym, w => w != null);
            DeleteWordCommand = new RelayCommand<EnglishWord>(DeleteWord, w => w != null);
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
                RaisePropertyChanged();
            }
        }


        public EnglishWord CurrentWord
        {
            get => currentWord;
            set
            {
                currentWord = value;

                // wtf? never did something like this
                AddSynonymCommand.RaiseCanExecuteChanged();
                AddNewWordCommand.RaiseCanExecuteChanged();
                EditWordCommand.RaiseCanExecuteChanged();
                DeleteWordCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged();
            }
        }

        public RelayCommand AddNewWordCommand { get; set; }
        public RelayCommand<EnglishWord> EditWordCommand { get; set; }
        public RelayCommand<EnglishWord> AddSynonymCommand { get; set; }
        public RelayCommand<EnglishWord> DeleteWordCommand { get; set; }


        private void AddNewWord()
        {
            Messenger.Default.Send(new ShowAddWordViewModelMessage(new EnglishWord(), "Add new"));
        }


        // todo: refactor
        private void EditWord(EnglishWord word)
        {
            Messenger.Default.Send(new ShowEditWordViewModelMessage(CurrentWord, "Edit word"));
        }

        private void AddSynonym(EnglishWord word)
        {
             
        }

        private void DeleteWord(EnglishWord word)
        {
            
        }
    }
}
