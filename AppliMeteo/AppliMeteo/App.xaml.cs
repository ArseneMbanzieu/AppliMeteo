using AppliMeteo.Helper;
using AppliMeteo.ViewModel;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppliMeteo
{
    public partial class App : Application
    {
        public static ViewModelLocator Locator { get; private set; }

        public App()
        {
            InitializeComponent();

            Locator = new ViewModelLocator();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnPropertyChanged([CallerMemberName] String propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName != nameof(MainPage)) return;
            var navigation = SimpleIoc.Default.GetInstance<INavigationService2>();
            navigation?.Initialize(MainPage);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

    }
}
