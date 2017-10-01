using GalaSoft.MvvmLight.Messaging;

namespace Vocabulary.Infrastructure.Messages
{
    public class ShowUserControlMessage: MessageBase { }

    public class HideUserControlMessage: MessageBase { }

    public class DialogResultOkMessage : HideUserControlMessage { }

    public class DialogResultCancelMessage: HideUserControlMessage { }
}
