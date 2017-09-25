/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WpfApp1"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using Vocabulary.Models.DataAccess;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.DataAccess.Repositories;
using Vocabulary.ViewModels;
using Vocabulary.Views;

namespace Vocabulary.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WordsListViewModel>();


            SimpleIoc.Default.Register<IEnglishWordRepository, DefaultEnglishWordRepository>();
            SimpleIoc.Default.Register(() => new Func<VocabularyContext>(() => new VocabularyContext()));

        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public WordsListViewModel WordsListViewModel => ServiceLocator.Current.GetInstance<WordsListViewModel>();


        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}