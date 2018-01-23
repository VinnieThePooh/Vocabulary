using System;
using MugenMvvmToolkit;
using Vocabulary.Core.ViewModels;

namespace Vocabulary.Core
{
    public class MugenApp: MvvmApplication
    {
        public override Type GetStartViewModelType() => typeof(MainViewModel);        
        
            

        
    }
}
