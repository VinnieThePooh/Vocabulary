using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Interfaces
{
    public interface IEnglishWordRepository
    {
        ObservableCollection<EnglishWord> GetAllWords();
        ObservableCollection<EnglishWord> GetWordsByFilter(Expression<Func<EnglishWord,bool>> filter);
        EnglishWord GetSingleWordByFilter(Expression<Func<EnglishWord,bool>> filter);
    }
}
