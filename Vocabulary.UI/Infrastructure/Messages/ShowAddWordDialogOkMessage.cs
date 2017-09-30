using System;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Models.Annotations;
using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Messages
{
    public class ShowAddWordDialogOkMessage : MessageBase
    {
        public ShowAddWordDialogOkMessage([NotNull] EnglishWord newWord)
        {
            NewWord = newWord ?? throw new ArgumentNullException(nameof(newWord));
        }

        public EnglishWord NewWord { get; }
    }
}
