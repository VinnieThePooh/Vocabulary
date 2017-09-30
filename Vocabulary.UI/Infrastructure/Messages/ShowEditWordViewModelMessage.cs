using System;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Messages    
{
    public class ShowEditWordViewModelMessage : MessageBase
    {
        public ShowEditWordViewModelMessage(EnglishWord word, string windowTitle)
        {
            if (string.IsNullOrEmpty(windowTitle)) throw new ArgumentNullException(nameof(windowTitle));
            WindowTitle = windowTitle;
            CurrentWord = word ?? throw new ArgumentNullException(nameof(word));
        }

        public EnglishWord CurrentWord { get; }
        public string WindowTitle { get; }
    }
}
