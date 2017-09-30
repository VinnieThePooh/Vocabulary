using System;
using GalaSoft.MvvmLight.Messaging;

namespace Vocabulary.Infrastructure.Messages
{
    public class ValidationErrorMessage : MessageBase
    {
        public ValidationErrorMessage(string message = "")
        {
            ErrorMessage = message ?? throw new ArgumentNullException(nameof(message));
        }

        public string ErrorMessage { get; }
    }
}
