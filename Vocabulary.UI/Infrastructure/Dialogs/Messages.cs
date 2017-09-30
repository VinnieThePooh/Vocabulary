using System;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Dialogs
{
    public class ShowUserControlMessage: MessageBase { }

    public class HideUserControlMessage: MessageBase { }

    public class DialogResultOkMessage : HideUserControlMessage { }

    public class DialogResultCancelMessage: HideUserControlMessage { }

    public class ShowEditWordViewModelMessage : MessageBase
    {
        public ShowEditWordViewModelMessage(EnglishWord word, string windowTitle)
        {
            if (string.IsNullOrEmpty(windowTitle)) throw new ArgumentNullException(nameof(windowTitle));
            WindowTitle = windowTitle;
            CurrentWord = word ?? throw new ArgumentNullException(nameof(word));
        }

        public EnglishWord CurrentWord { get;}
        public string WindowTitle { get; }
    }

    public class ShowAddWordViewModelMessage : ShowEditWordViewModelMessage
    {
        public ShowAddWordViewModelMessage(EnglishWord word, string windowTitle):base(word, windowTitle)
        {
            
        }
    }
}
