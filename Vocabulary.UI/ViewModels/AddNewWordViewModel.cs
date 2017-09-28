using GalaSoft.MvvmLight.Command;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;
using Vocabulary.Models.Validators;

namespace Vocabulary.ViewModels
{
   public class AddNewWordViewModel: EditWordViewModel
    {
        public AddNewWordViewModel(IEnglishWordRepository wordsRepository, EnglishWord currentWord, IWordValidator validator):
            base(wordsRepository, currentWord, validator)
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
