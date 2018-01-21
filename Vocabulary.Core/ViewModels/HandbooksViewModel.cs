using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Infrastructure;

namespace Vocabulary.Core.ViewModels
{
   public class HandbooksViewModel: ViewModelBase
    {
        #region Properties

        public List<TabItemCommandParameter> ViewModels { get; } = new List<TabItemCommandParameter>();

        #endregion
    }
}
