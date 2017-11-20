using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using Vocabulary.Infrastructure;

namespace Vocabulary.ViewModels
{
    /// </para>
    /// </summary>
    public class MainViewModel : MultiViewModel<ItemViewModelBase>
    {
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
            ReopenApplicationCommand = new AsyncRelayCommand(ReopenApp, CanReopenApp);

            AddViewModel(GetViewModel<WordsListItemViewModel>(),true);
            AddViewModel(GetViewModel<HandBooksItemViewModel>(),false);
            //AddViewModel(GetViewModel<WordsListItemViewModel>(),false);
            //AddViewModel(GetViewModel<WordsListItemViewModel>(),false);
            //AddViewModel(GetViewModel<WordsListItemViewModel>(),false);
        }



        #endregion

        #region Properties


        


        

        #region Commands

        public AsyncRelayCommand ExitCommand { get; }

        public AsyncRelayCommand ReopenApplicationCommand { get; } // is not implemented yet

        #endregion


        #endregion

        #region Implementation details

        private Task ExitFromApplication()
        {
            return Task.Run(() =>
            {

            });
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
            return Task.Run(() =>
            {

            });
        }

        #endregion
    }
}


        
    
