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
        Task<ObservableCollection<EnglishWord>> GetAllWords();
        Task<ObservableCollection<EnglishWord>> GetWordsByFilter(Expression<Predicate<EnglishWord>> filter);
        Task<EnglishWord> GetSingleWordByFilter(Expression<Predicate<EnglishWord>> filter);
    }
}
