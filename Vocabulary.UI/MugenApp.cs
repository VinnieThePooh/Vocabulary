using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using Vocabulary.ViewModels;

namespace Vocabulary
{
    public class MugenApp: MvvmApplication
    {
        public override Type GetStartViewModelType() => typeof(MainViewModel);
    }
}
