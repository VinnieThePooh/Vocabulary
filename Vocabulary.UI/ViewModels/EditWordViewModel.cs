using System;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;
using Vocabulary.Models.Validators;

namespace Vocabulary.ViewModels
{
    // must be as abstract base class actually
   public class EditWordViewModel: ViewModelBase
    {
        #region Fields

        protected readonly IEnglishWordRepository wordsRepository;
        protected readonly IWordValidator wordValidator;
        private string validationMessage;

        #endregion

        #region Constructors

        public EditWordViewModel(IEnglishWordRepository wordsRepository, EnglishWord currentWord, IWordValidator validator)
        {
            wordValidator = validator ?? throw new ArgumentNullException(nameof(wordValidator));
            CurrentWord = currentWord ?? throw new ArgumentNullException(nameof(currentWord));
            wordsRepository = wordsRepository ?? throw new ArgumentNullException(nameof(wordsRepository));
            SaveChangesCommand = new RelayCommand<EnglishWord>(SaveChanges);
        }

        #endregion

        #region Properties

        public EnglishWord CurrentWord { get; set; }

        public RelayCommand<EnglishWord> SaveChangesCommand { get; set; }

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

        public void SaveChanges(EnglishWord updatedWord)
        {
            if (!Validate(updatedWord))
            {
                var keyValue = wordValidator.Errors.First(e => e.Value.Any());
                ValidationMessage = keyValue.Value.First();
                return;
            }
            SaveChangesInternal(updatedWord);
        }

        #endregion

        #region Implementation details

        protected virtual bool Validate(EnglishWord updatedWord)
        {
            wordValidator.Validate(updatedWord, false);
            return !wordValidator.HasErrors;
        }

        protected virtual void SaveChangesInternal(EnglishWord updatedWord) => wordsRepository.UpdateWord(updatedWord);

        #endregion
    }
}
