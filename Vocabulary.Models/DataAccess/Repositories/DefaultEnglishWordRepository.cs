using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Repositories
{
   public class DefaultEnglishWordRepository: IEnglishWordRepository
   {
        private readonly Func<VocabularyContext> vocabularyContext;

        public DefaultEnglishWordRepository(Func<VocabularyContext> context)
        {
            vocabularyContext = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public ObservableCollection<EnglishWord> GetAllWords()
        {
            using (var context = vocabularyContext())
            {
                return new ObservableCollection<EnglishWord>(context.Words);
            }
        }

        public ObservableCollection<EnglishWord> GetWordsByFilter(Expression<Func<EnglishWord,bool>> filter)
        {
            using (var context = vocabularyContext())
            {
                return new ObservableCollection<EnglishWord>(context.Words.Where(filter));
            }
        }

        public EnglishWord GetSingleWordByFilter(Expression<Func<EnglishWord,bool>> filter)
        {
            using (var context = vocabularyContext())
            {
                return context.Words.SingleOrDefault(filter);
            }
        }

       public int AddNewWord(EnglishWord word)
       {
           if (word == null) throw new ArgumentNullException(nameof(word));
           using (var context = vocabularyContext())
           {
               word.AdditionDate = DateTime.Now;
               var newlyAddedWord = context.Words.Add(word);
               context.SaveChanges();
               return newlyAddedWord.EnglishWordId;
           }
        }
   }
}
