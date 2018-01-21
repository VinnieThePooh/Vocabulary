using System;
using System.Threading;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Vocabulary.Core.ViewModels.Abstract
{
    public abstract class TabItemViewModelBase : ViewModelBase, IHasDisplayName
    {
        #region Fields

        private static int _counter;

        #endregion

        #region Constructors

        protected TabItemViewModelBase()
        {
            Id = Interlocked.Increment(ref _counter);
        }

        protected TabItemViewModelBase(string displayName):this()
        {
            if (string.IsNullOrEmpty(displayName))
                   throw new ArgumentException(nameof(displayName));
            DisplayName = displayName;
            Name = displayName;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public int Id { get; }

        public string DisplayName { get; set; }

        public abstract ViewModelBase ContentViewModel { get; set; }

        #endregion
    }
}
