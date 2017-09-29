using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Vocabulary.Models.DataAccess.Interfaces;
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
        private EnglishWord originWord;

        #endregion

        #region Constructors

        public EditWordViewModel(IEnglishWordRepository wordsRepository, IWordValidator validator)
        {
            wordValidator = validator ?? throw new ArgumentNullException(nameof(wordValidator));
            wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
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

        public void SaveOrigin(EnglishWord word)
        {
            if (word == null) throw new ArgumentNullException(nameof(word));
            originWord = CloneWord(word);
        }

        public override void HandleDialogResultOk() => SaveChanges(CurrentWord);

        public override void HandleDialogResultCancel() => CancelChanges();

        #endregion

        #region Implementation details

        private void SaveChanges(EnglishWord updatedWord)
        {
            if (!Validate(updatedWord))
            {
                var keyValue = wordValidator.Errors.First(e => e.Value.Any());
                ValidationMessage = keyValue.Value.First();
                return;
            }
            SaveChangesInternal(updatedWord);
        }

        private void CancelChanges()
        {
            CurrentWord = originWord;
        }

        private EnglishWord CloneWord(EnglishWord word)
        {
            if (word == null)
                return null;

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, word);
                stream.Position = 0;
                return (EnglishWord) formatter.Deserialize(stream);
            }
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
