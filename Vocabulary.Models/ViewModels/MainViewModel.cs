using System.Threading.Tasks;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Core.ViewModels.Abstract;

namespace Vocabulary.Core.ViewModels
{
    /// <summary>
    ///  Entry view model
    /// </summary>
    public class MainViewModel : MultiViewModel<TabItemViewModelBase>, IHasDisplayName
    {
        private readonly string _displayName;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        #region Fields

        #endregion

        #region Constructor

        //todo: pass literals via resources
        public MainViewModel()
        {
            ExitCommand = new AsyncRelayCommand(ExitFromApplication, CanExitFromApplication);
            ReopenAppCommand = new AsyncRelayCommand(ReopenApp, CanReopenApp);

            var wvm = GetViewModel<WordsListTabItemViewModel>();
            // todo: refactor it
            wvm.DisplayName = "Words";
            wvm.Name = wvm.DisplayName;

            AddViewModel(wvm);
            var vm = GetViewModel<HandBooksTabItemViewModel>();
            vm.DisplayName = "Handbooks";
            vm.Name = vm.DisplayName;
            AddViewModel(vm, false);
        }
        #endregion

        #region Properties

        public override TabItemViewModelBase SelectedItem
        {
            get => base.SelectedItem;
            set
            {
                base.SelectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        #region Commands

        public AsyncRelayCommand ExitCommand { get; }

        public AsyncRelayCommand ReopenAppCommand { get; } // is not implemented yet

        #endregion

        #endregion

        #region Implementation details

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
            return CanClose(null);
        }

        private Task ReopenApp()
        {
            return Task.Run(() => { });
        }

        #endregion

        public string DisplayName => _displayName;
    }
}