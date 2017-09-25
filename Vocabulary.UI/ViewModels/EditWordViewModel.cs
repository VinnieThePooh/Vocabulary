using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.ViewModels
{
   public class EditWordViewModel: ViewModelBase
    {
        private readonly IEnglishWordRepository wordsRepository;

        public EditWordViewModel(IEnglishWordRepository wordsRepository, EnglishWord currentWord)
        {
            CurrentWord = currentWord ?? throw new ArgumentNullException(nameof(currentWord));
            wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
            SaveChangesCommand = new RelayCommand<EnglishWord>(SaveChanges);
        }

        public EnglishWord CurrentWord { get; set; }

        public RelayCommand<EnglishWord> SaveChangesCommand { get; set; }


        private void SaveChanges(EnglishWord updatedWord)
        {
            
        }
    }
}
