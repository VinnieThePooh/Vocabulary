using System;
using System.Collections.Generic;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.ViewModels.Abstract;
using Vocabulary.Core.ViewModels.Handbooks;

namespace Vocabulary.Core.ViewModels
{
    // todo: check it later
    public class HandBooksTabItemViewModel: TabItemViewModelBase
    {
        #region Constructors

        public HandBooksTabItemViewModel()
        {
            ContentViewModel = GetViewModel<HandbooksViewModel>();
        }

        public HandBooksTabItemViewModel(string displayName):base(displayName)
        {
            ContentViewModel = GetViewModel<HandbooksViewModel>();
        }

        #endregion

        #region Properties

        #endregion



        public override ViewModelBase ContentViewModel { get; set; }
    }
}
