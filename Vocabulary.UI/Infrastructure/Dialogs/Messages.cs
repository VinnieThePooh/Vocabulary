using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace Vocabulary.Infrastructure.Dialogs
{
    public class ShowUserControlMessage: MessageBase { }

    public class HideUserControlMessage: MessageBase { }

    public class DialogResultOkMessage : HideUserControlMessage { }

    public class DialogResultCancelMessage: HideUserControlMessage { }

    public class ShowEditWordViewModel: MessageBase { }

    public class ShowAddWordViewModel: MessageBase { }
}
