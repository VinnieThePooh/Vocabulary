using System;
using GalaSoft.MvvmLight.Messaging;
using Vocabulary.Models.Annotations;
using Vocabulary.Models.Models;

namespace Vocabulary.Infrastructure.Dialogs
{
    public class ShowUserControlMessage: MessageBase { }

    public class HideUserControlMessage: MessageBase { }

    public class DialogResultOkMessage : HideUserControlMessage { }

    public class DialogResultCancelMessage: HideUserControlMessage { }
}
