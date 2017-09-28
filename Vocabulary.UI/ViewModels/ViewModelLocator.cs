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

using System;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Vocabulary.Models.DataAccess;
using Vocabulary.Models.DataAccess.Interfaces;
using Vocabulary.Models.DataAccess.Repositories;

namespace Vocabulary.ViewModels
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
            SimpleIoc.Default.Register<EditWordViewModel>();
            SimpleIoc.Default.Register<AddNewWordViewModel>();
            
            SimpleIoc.Default.Register<IEnglishWordRepository, DefaultEnglishWordRepository>();
            SimpleIoc.Default.Register(() => new Func<VocabularyContext>(() => new VocabularyContext()));

        }

        public static MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public static WordsListViewModel WordsListViewModel => ServiceLocator.Current.GetInstance<WordsListViewModel>();

        public static AddNewWordViewModel AddNewWordViewModel => ServiceLocator.Current.GetInstance<AddNewWordViewModel>();

        public static EditWordViewModel EditWordViewModel => ServiceLocator.Current.GetInstance<EditWordViewModel>();



        public static void Cleanup()
        {
            EditWordViewModel?.Cleanup();
            MainViewModel?.Cleanup();
            AddNewWordViewModel?.Cleanup();
            WordsListViewModel?.Cleanup();
        }
    }
}