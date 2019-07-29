using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppliMeteo.Helper
{
    public interface INavigationService2 : INavigationService
    {
        //On ajoute via interface d'autres méthodes "oubliées" de l'interface de référence
        Task ModalNavigateTo(string pageKey);
        Task ModalNavigateTo(string pageKey, object parameter, bool animate = true);
        Task ModalDismiss();
        void NavigateTo(string pageKey, object parameter, bool animate);
        void Initialize(Page navigationPage);
    }
}
