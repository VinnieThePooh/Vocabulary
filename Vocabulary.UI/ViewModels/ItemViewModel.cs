using System;
using System.Threading;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace Vocabulary.ViewModels
{
    public class ItemViewModelBase : ViewModelBase, IHasDisplayName
    {
        #region Fields

        private static int _counter;

        #endregion

        #region Constructors

        public ItemViewModelBase()
        {
            Id = Interlocked.Increment(ref _counter);
        }

        public ItemViewModelBase(string displayName):this()
        {
            if (string.IsNullOrEmpty(displayName))
                   throw new ArgumentException(nameof(displayName));
            DisplayName = displayName;
            // default as display name
            Name = displayName;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public int Id { get; }

        public string DisplayName { get; }

        public ViewModelBase ContentViewModel { get; set; } 

        #endregion
    }
}
