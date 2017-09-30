using System;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;
using Vocabulary.Infrastructure.Messages;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;
using Vocabulary.Models.Validators;

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

        [PreferredConstructor]
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
                Messenger.Default.Send(new DialogResultOkMessage());
                Messenger.Default.Send(new ShowAddWordDialogOkMessage(CurrentWord));
                return;
            }
            Messenger.Default.Send(new ValidationErrorMessage(ValidationMessage));
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
