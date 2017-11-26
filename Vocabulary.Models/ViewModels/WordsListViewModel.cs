using System;
using System.Threading.Tasks;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.DataAccess.Interfaces;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.ViewModels
{
   public class WordsListViewModel: GridViewModel<EnglishWord>
    {
        #region Fields

        readonly IEnglishWordRepository wordsRepository;

        #endregion

        #region Constructors

        public WordsListViewModel(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            AddNewWordCommand = new AsyncRelayCommand<EnglishWord>(AddNewWord, CanAddWord,this);
            EditWordCommand = new AsyncRelayCommand<EnglishWord>(EditWord, CanEditWord,this);
            AddSynonymCommand = new AsyncRelayCommand<EnglishWord>(AddSynonym, CanAddSynonym, this);
            DeleteWordCommand = new AsyncRelayCommand<EnglishWord>(DeleteWord, CanDeleteWord, this);
        }

        #endregion

        #region Properties

        public AsyncRelayCommand<EnglishWord> AddNewWordCommand { get;}
        public AsyncRelayCommand<EnglishWord> EditWordCommand { get; }
        public AsyncRelayCommand<EnglishWord> AddSynonymCommand { get; }
        public AsyncRelayCommand<EnglishWord> DeleteWordCommand { get; }

        #endregion

        #region Implementation details

        private Task AddNewWord(EnglishWord word)
        {
            return Task.Run(() => { });
        }

        // todo: refactor
        private Task EditWord(EnglishWord word)
        {
            return Task.Run(() => { });
        }

        private Task AddSynonym(EnglishWord word)
        {
            return Task.Run(() => { });
        }

        private Task DeleteWord(EnglishWord word)
        {
            return Task.Run(() => { });
        }


        private bool CanDeleteWord(EnglishWord arg)
        {
            return SelectedItem != null;
        }

        private bool CanAddSynonym(EnglishWord arg)
        {
            return SelectedItem != null;
        }

        private bool CanEditWord(EnglishWord arg)
        {
            return SelectedItem != null;
        }

        private bool CanAddWord(EnglishWord arg)
        {
            return true;
        }

        #endregion
    }
}
