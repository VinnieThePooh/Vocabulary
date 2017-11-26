using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.ViewModels.Handbooks;

namespace Vocabulary.Core.ViewModels
{
   public class HandbooksViewModel: ViewModelBase
    {
        #region Properties

        // todo: dedicate string literals
        public IList<Tuple<string, ViewModelCommandParameter>> Items { get; } = new[] {
            Tuple.Create("Consumption areas", new ViewModelCommandParameter(typeof(ConsAreasTabItemViewModel))),
            Tuple.Create("Speech parts", new ViewModelCommandParameter(typeof(SpeechPartTabItemViewModel)))
        };


        #endregion
    }
}
