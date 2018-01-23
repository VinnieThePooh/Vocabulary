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

            if (viewModelType == null)
                throw new ArgumentNullException(nameof(viewModelType));

            ViewModelType = viewModelType;
            TabItemDisplayName = tabItemDisplayName;
        }

        #endregion

        #region Properties

        public Type ViewModelType { get; }

        public string TabItemDisplayName { get; }

        #endregion
    }
}
