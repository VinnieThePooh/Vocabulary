using System;
using GalaSoft.MvvmLight.Ioc;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;
using Vocabulary.Models.Validators;

namespace Vocabulary.ViewModels
{
   public class AddNewWordViewModel: EditWordViewModel
    {
        
        public AddNewWordViewModel(IEnglishWordRepository wordsRepository, IWordValidator validator,
            EnglishWord englishWord) : base(wordsRepository, validator)
        {
            CurrentWord = englishWord ?? throw new ArgumentNullException(nameof(englishWord));
        }

        [PreferredConstructor]
        public AddNewWordViewModel(IEnglishWordRepository wordsRepository, IWordValidator validator):
            base(wordsRepository, validator)
        {
        }

        protected override bool Validate(EnglishWord updatedWord)
        {
            wordValidator.Validate(updatedWord);
            return !wordValidator.HasErrors;
        }

        protected override void SaveChangesInternal(EnglishWord updatedWord) => wordsRepository.AddNewWord(updatedWord);
    }
}
