using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Messages
{
    public class ShowAddWordViewModelMessage : ShowEditWordViewModelMessage
    {
        public ShowAddWordViewModelMessage(EnglishWord word, string windowTitle) : base(word, windowTitle)
        {

        }
    }
}
