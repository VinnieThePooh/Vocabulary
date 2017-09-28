using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.DataAccess.Repositories
{
   public class DefaultEnglishWordRepository: IEnglishWordRepository
   {
        private readonly Func<VocabularyContext> getContext;

        public DefaultEnglishWordRepository(Func<VocabularyContext> context)
        {
            getContext = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        public ObservableCollection<EnglishWord> GetAllWords()
        {
            using (var context = getContext())
            {
                return new ObservableCollection<EnglishWord>(context.Words.ToArray());
            }
        }

        public ObservableCollection<EnglishWord> GetWordsByFilter(Expression<Func<EnglishWord,bool>> filter)
        {
            using (var context = getContext())
            {
                return new ObservableCollection<EnglishWord>(context.Words.Where(filter).ToArray());
            }
        }

        public EnglishWord GetSingleWordByFilter(Expression<Func<EnglishWord,bool>> filter)
        {
            using (var context = getContext())
            {
                return context.Words.SingleOrDefault(filter);
            }
        }

       public int AddNewWord(EnglishWord word)
       {
           if (word == null) throw new ArgumentNullException(nameof(word));
           using (var context = getContext())
           {
               word.AdditionDate = DateTime.Now;
               var newlyAddedWord = context.Words.Add(word);
               context.SaveChanges();
               return newlyAddedWord.EnglishWordId;
           }
        }

       public void UpdateWord(EnglishWord updatedWord)
       {
           if (updatedWord == null) throw new ArgumentNullException(nameof(updatedWord));

           using (var context = getContext())
           {
               context.Set<EnglishWord>().Attach(updatedWord);
               context.Entry(updatedWord).State = EntityState.Modified;
               context.SaveChanges();
           }
       }
   }
}
