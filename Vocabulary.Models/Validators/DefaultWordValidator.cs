using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using Vocabulary.Core.DataAccess.Interfaces;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.Validators
{
    public class DefaultWordValidator: IWordValidator
    {
        private readonly IEnglishWordRepository wordsRepository;


        public DefaultWordValidator(IEnglishWordRepository repository)
        {
            wordsRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            Errors = new Dictionary<string, List<string>>();
            InitState();
        }


        public IDictionary<string, List<string>> Errors { get; }
        public void Validate(EnglishWord entity, bool addNew=true)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            ClearState();

            if (string.IsNullOrEmpty(entity.Text))
            {
                HasErrors = true;
                Errors[nameof(EnglishWord.Text)].Add(Resources.ValTextCantBeEmpty);
                return;
            }
            
            Expression<Func<EnglishWord, bool>> predicate;
            var lowerText = entity.Text.ToLower(CultureInfo.InvariantCulture);
            if (!addNew)
                predicate = w => w.Text.ToLower().Equals(lowerText) && !w.EnglishWordId.Equals(entity.EnglishWordId);
            else
                predicate = w => w.Text.ToLower().Equals(lowerText);

            var word = wordsRepository.GetSingleWordByFilter(predicate);
            if (word != null)
            {
                HasErrors = true;
                Errors[nameof(EnglishWord.Text)].Add(String.Format(Resources.ValTextWordAlreadyExists, entity.Text));
            }
        }
         
        public bool HasErrors { get; private set; }


        private void InitState()
        {
            HasErrors = false;
            foreach (var propertyInfo in typeof(EnglishWord).GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                Errors.Add(propertyInfo.Name,new List<string>());
            }
        }

        private void ClearState()
        {
            HasErrors = false;
            foreach (var key in Errors.Keys)
              Errors[key].Clear();
        }

    }
}
