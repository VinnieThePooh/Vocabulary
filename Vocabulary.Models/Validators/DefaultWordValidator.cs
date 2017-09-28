﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.Validators
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
        public void Validate(EnglishWord entity, bool checkIsUnique=true)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            ClearState();

            if (string.IsNullOrEmpty(entity.Text))
            {
                HasErrors = true;
                Errors[nameof(EnglishWord.Text)].Add(Resources.ValTextCantBeEmpty);
                return;
            }

            if (!checkIsUnique)
                return;

            var word = wordsRepository.GetSingleWordByFilter(w => w.Text.Equals(entity.Text));
            if (word != null)
            {
                HasErrors = true;
                Errors[nameof(EnglishWord.Text)].Add(String.Format(Resources.ValTextWordAlreadyExists,entity.Text));
                return;
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