using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.Infrastructure;
using Vocabulary.Core.Models;

namespace Vocabulary.Core.ViewModels
{
    /// <summary>
    ///     Entry view model
    /// </summary>
    public sealed class MainViewModel : WorkspaceViewModel
    {
        private TabItemCommandParameter selectedTabItem;
        private ViewModelBase currentViewModel;

        #region Properties

        public TabItemCommandParameter SelectedTabItem
        {
            get { return selectedTabItem; }
            set
            {
                selectedTabItem = value;
                CurrentViewModel = (ViewModelBase)ViewModelProvider.GetViewModel(selectedTabItem.ViewModelType);
                OnPropertyChanged(nameof(SelectedTabItem));
            }
        }

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value; 
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public List<TabItemCommandParameter> ViewModels { get; set; } = new List<TabItemCommandParameter>();

        public AsyncRelayCommand ExitCommand { get; private set; }

        public AsyncRelayCommand ReopenAppCommand { get; private set; }

        public AsyncRelayCommand AddNewWordCommand { get; private set; }


        #endregion

        #region Implementation details

        protected override void OnInitialized()
        {
            base.OnInitialized();
            ExitCommand = new AsyncRelayCommand(ExitFromApplication, CanExitFromApplication);
            ReopenAppCommand = new AsyncRelayCommand(ReopenApp, CanReopenApp);            

            ViewModels.AddRange(new []
            {
                new TabItemCommandParameter(typeof(WordsListViewModel), Resources.TabTitleWords),
                new TabItemCommandParameter(typeof(HandBooksTabItemViewModel), Resources.TabTitleHandbooks)
            });

            SelectedTabItem = ViewModels.First();
        }

        private async Task ExitFromApplication()
        {
            await this.CloseAsync();
        }

              

        private bool CanReopenApp()
        {
            return true;
        }

        private bool CanExitFromApplication()
        {
            return true;
        }

        private Task ReopenApp()
        {
            return Task.Run(() => { });
        }

        #endregion
    }
}