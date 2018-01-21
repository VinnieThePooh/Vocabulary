using System;

namespace Vocabulary.Core.Infrastructure
{
    public class TabItemCommandParameter
    {

        #region Constructors

        public TabItemCommandParameter(Type viewModelType, string tabItemDisplayName)
        {
            if (string.IsNullOrEmpty(tabItemDisplayName))
               throw new ArgumentNullException(nameof(tabItemDisplayName));
            ViewModelType = viewModelType ?? throw new ArgumentNullException(nameof(viewModelType));
            TabItemDisplayName = tabItemDisplayName;
        }

        #endregion

        #region Properties

        public Type ViewModelType { get; }

        public string TabItemDisplayName { get; }

        #endregion
    }
}
