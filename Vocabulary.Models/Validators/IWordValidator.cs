using System.Collections.Generic;
using System.ComponentModel.Design;
using Vocabulary.Models.Models;

namespace Vocabulary.Models.Validators
{
    public interface IWordValidator
    {
        IDictionary<string,List<string>> Errors { get; }
        void Validate(EnglishWord entity, bool addNew = true);
        bool HasErrors { get;}
    }
}
