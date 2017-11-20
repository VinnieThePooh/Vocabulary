using System;
using Vocabulary.Core.DataAccess.Interfaces;
using Vocabulary.Core.Models;
using Vocabulary.Core.Validators;

namespace Vocabulary.ViewModels
{
   public class AddNewWordViewModel: EditWordViewModel
    {
        #region Constructors

        public AddNewWordViewModel(IEnglishWordRepository wordsRepository, IWordValidator validator,
            EnglishWord englishWord) : base(validator,wordsRepository)
        {
            CurrentWord = englishWord ?? throw new ArgumentNullException(nameof(englishWord));
        }

        //[PreferredConstructor]
        public AddNewWordViewModel(IEnglishWordRepository wordsRepository, IWordValidator validator):
            base(validator, wordsRepository)
        {
        }

        #endregion

        #region Interface

        public override void HandleDialogResultOk()
        {
            ValidationMessage = string.Empty;
            var result = SaveChanges(CurrentWord);
            if (result)
            {
                //Messenger.Default.Send(new DialogResultOkMessage());
                //Messenger.Default.Send(new ShowAddWordDialogOkMessage(CurrentWord));
                return;
            }
            //Messenger.Default.Send(new ValidationErrorMessage(ValidationMessage));
        }

        public override void HandleDialogResultCancel()
        {
            // no need in logic here
        }

        #endregion



        #region Implementation details

        protected override bool Validate(EnglishWord updatedWord)
        {
            wordValidator.Validate(updatedWord);
            return !wordValidator.HasErrors;
        }

        protected override void SaveChangesInternal(EnglishWord updatedWord)
        {
            var key = wordsRepository.AddNewWord(updatedWord);
            CurrentWord.EnglishWordId = key;
        }
       

        #endregion
    }
}
