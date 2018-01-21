using System;
using Vocabulary.Core.ViewModels;
using MugenMvvmToolkit;

namespace Vocabulary
{
    public class MugenApp: MvvmApplication
    {
        public override Type GetStartViewModelType() => typeof(MainViewModel);
    }
}
