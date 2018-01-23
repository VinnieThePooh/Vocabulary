using MugenMvvmToolkit.WPF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces;
using Vocabulary.Core;
using JetBrains.Annotations;
using MugenMvvmToolkit.Models;
using System.Windows;
using Vocabulary.Core.Annotations;
using MugenMvvmToolkit;

namespace Vocabulary
{
    public sealed class Setup : WpfBootstrapperBase
    {
        public Setup([NotNull] Application application, bool autoStart = true, PlatformInfo platform = null) : base(application, autoStart, platform)
        {
        }

        protected override IMvvmApplication CreateApplication()
        {
            return new MugenApp();            
        }

        protected override IIocContainer CreateIocContainer()
        {
            return new MugenContainer();
        }
    }
}
