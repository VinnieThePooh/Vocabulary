using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.DataAccess.Interfaces
{
    public interface IEnglishWordRepository
    {
        ObservableCollection<EnglishWord> GetAllWords();
        ObservableCollection<EnglishWord> GetWordsByFilter(Expression<Func<EnglishWord,bool>> filter);
        EnglishWord GetSingleWordByFilter(Expression<Func<EnglishWord,bool>> filter);
        int AddNewWord(EnglishWord word);
        void UpdateWord(EnglishWord updatedWord);
    }
}
