using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Dialogs
{
    public class ShowUserControlMessage: MessageBase { }

    public class HideUserControlMessage: MessageBase { }

    public class DialogResultOkMessage : HideUserControlMessage { }

    public class DialogResultCancelMessage: HideUserControlMessage { }

    // todo: refactor, wtf is this? messaging system
    public class ShowEditWordViewModel : MessageBase
    {
        public ShowEditWordViewModel(EnglishWord word, string windowTitle)
        {
            if (string.IsNullOrEmpty(windowTitle)) throw new ArgumentNullException(nameof(windowTitle));
            WindowTitle = windowTitle;
            CurrentWord = word ?? throw new ArgumentNullException(nameof(word));
        }

        public EnglishWord CurrentWord { get;}
        public string WindowTitle { get; }
    }

    public class ShowAddWordViewModel : ShowEditWordViewModel
    {
        public ShowAddWordViewModel(EnglishWord word, string windowTitle):base(word, windowTitle)
        {
            
        }
    }
}
