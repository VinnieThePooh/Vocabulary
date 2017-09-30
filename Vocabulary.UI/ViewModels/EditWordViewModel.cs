using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Infrastructure.Dialogs;
using Vocabulary.Infrastructure.Helpers;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Infrastructure;
using Vocabulary.Models.Models;
using Vocabulary.Models.Validators;
using Vocabulary.ViewModels.Abstract;


namespace Vocabulary.ViewModels
{
    // must be as abstract base class actually
   public class EditWordViewModel: NotifiableViewModelBase
    {
        #region Fields

        protected readonly IEnglishWordRepository wordsRepository;
        protected readonly IWordValidator wordValidator;
        private string validationMessage;
        private EnglishWord currentWord;

        #endregion

        #region Constructors

        public EditWordViewModel(IWordValidator validator, IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            wordValidator = validator ?? throw new ArgumentNullException(nameof(wordValidator));
            Cultures = CulturesHelper.GetAllCultures();
        }

        

        #endregion

        #region Properties

        public EnglishWord CurrentWord
        {
            get => currentWord;
            set
            {
                currentWord = value;
                RaisePropertyChanged();
            }
        }

        public IEnumerable<Culture> Cultures { get;}

        public EnglishWord OriginalWord { get; private set; }
        
        public string ValidationMessage
        {
            get => validationMessage;
            private set
            {
                validationMessage = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Interface

        public override void HandleDialogResultOk()
        {
            SaveChanges(CurrentWord);
        }

        public override void HandleDialogResultCancel()
        {
            RestoreOriginalValues();
        }

        public void SaveOriginalWord(EnglishWord word)
        {
            if (word == null)
                throw new ArgumentNullException(nameof(word));
            OriginalWord = CloneWord(word);
        }

        #endregion

        #region Implementation details

        private void RestoreOriginalValues()
        {
            CurrentWord.Text = OriginalWord.Text;
            CurrentWord.Culture = OriginalWord.Culture;
            CurrentWord.Transcription = OriginalWord.Transcription;
            CurrentWord.Translations = OriginalWord.Translations;
            CurrentWord.Synonyms = OriginalWord.Synonyms;
        }

        private void SaveChanges(EnglishWord updatedWord)
        {
            if (!Validate(updatedWord))
            {
                var keyValue = wordValidator.Errors.First(e => e.Value.Any());
                ValidationMessage = keyValue.Value.First();
                return;
            }
            SaveChangesInternal(updatedWord);
            Messenger.Default.Send(new ShowEditViewModelDialogOkMessage(CurrentWord));
        }
        
        private EnglishWord CloneWord(EnglishWord word)
        {
            var clone = new EnglishWord
            {
                EnglishWordId = word.EnglishWordId,
                Text = word.Text,
                Culture = word.Culture,
                AdditionDate = word.AdditionDate,
                Synonyms = word.Synonyms,
                Translations = word.Translations,
                Transcription = word.Transcription
            };
            return clone;
        }

        protected virtual bool Validate(EnglishWord updatedWord)
        {
            wordValidator.Validate(updatedWord, false);
            return !wordValidator.HasErrors;
        }

        protected virtual void SaveChangesInternal(EnglishWord updatedWord) => wordsRepository.UpdateWord(updatedWord);

        #endregion
    }
}
