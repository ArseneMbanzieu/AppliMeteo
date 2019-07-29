using AppliMeteo.Helper;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppliMeteo.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
            //Préparation de la navigation pur l'injection
            var navigation = new NavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigation);
            SimpleIoc.Default.Register<INavigationService2>(() => navigation);

            initializeNavigation(navigation);
        }

        //Qui est la page à la base de la navigation ?
        //C'est MainPage
        private static void initializeNavigation(NavigationService navigation)
        {
            //J'initialise une "clé-valeur" pour la base de la navigation
            navigation.Configure(PageName.MainPage.ToString(), typeof(MainPage));
            navigation.Configure(PageName.SecondPage.ToString(), typeof(SecondPage));
            //enregistrement de la MainViewModel
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<SecondViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return SimpleIoc.Default.GetInstance<MainViewModel>();
            }
        }

        public SecondViewModel Second
        {
            get
            {
                return SimpleIoc.Default.GetInstance<SecondViewModel>();
            }
        }

        public INavigationService NavigationService
        {
            get
            {
                return SimpleIoc.Default.GetInstance<INavigationService>();
            }
        }

        public INavigationService2 NavigationService2
        {
            get
            {
                return SimpleIoc.Default.GetInstance<INavigationService2>();
            }
        }

    }
}
