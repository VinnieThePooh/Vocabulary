using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Practices.ServiceLocation;
using Vocabulary.Infrastructure;

namespace Vocabulary.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        #region Fields

        
        private ViewModelBase dynamicViewModel;

        private ViewModelBase wordsListViewModel;
        private TabItemModel selectedTabItem;

        #endregion

        #region Constructor

        //todo: pass literals via resources
        public MainViewModel()
        {
            ExitCommand = new RelayCommand<Window>(ExitFromApplication);
            ReopenApplicationCommand = new RelayCommand(ReopenApp);
            TabItemsCollection = new ObservableCollection<TabItemModel>(new List<TabItemModel>
            {
                new TabItemModel {TabItemTitle = "List", ViewModelType = typeof(WordsListViewModel)},
                new TabItemModel {TabItemTitle = "TestTabItem", ViewModelType = null},
                new TabItemModel {TabItemTitle = "TestTabItem2", ViewModelType = null}
            });
            SelectedTabItem = TabItemsCollection[0];
        }



        #endregion

        #region Properties


        public ViewModelBase DynamicViewModel
        {
            get => dynamicViewModel;
            set
            {
                if (value == dynamicViewModel)
                    return;
                dynamicViewModel = value;
                RaisePropertyChanged();
            }
        }


        public ObservableCollection<TabItemModel> TabItemsCollection { get; }
         
        public TabItemModel SelectedTabItem
        {
            get => selectedTabItem;
            set
            {
                TabItemModel val = value;
                if (val?.ViewModelType == null)
                    return;
                
                selectedTabItem = value;
                var t = (ViewModelBase)ServiceLocator.Current.GetInstance(selectedTabItem.ViewModelType);
                DynamicViewModel = t;
                RaisePropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<Window> ExitCommand { get; }

        public RelayCommand ReopenApplicationCommand { get;}

        #endregion


        #endregion

        #region Implementation details

        private void ExitFromApplication(Window window) => window?.Close();

        private void ReopenApp()
        {
            
        }

        #endregion
    }
}

        
    
