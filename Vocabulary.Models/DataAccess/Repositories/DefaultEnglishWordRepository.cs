using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Repositories
{
   public class DefaultEnglishWordRepository: IEnglishWordRepository
    {
        public ObservableCollection<EnglishWord> GetAllWords()
        {
            return new ObservableCollection<EnglishWord>(new List<EnglishWord>
            {
                new EnglishWord {Text = "collateral", EnglishWordId = 1},
                new EnglishWord {Text = "rutter", EnglishWordId = 2}
            });
        }

        public ObservableCollection<EnglishWord> GetWordsByFilter(Expression<Predicate<EnglishWord>> filter)
        {
            throw new NotImplementedException();
        }

        public EnglishWord GetSingleWordByFilter(Expression<Predicate<EnglishWord>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
