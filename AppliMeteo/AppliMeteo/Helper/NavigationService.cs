using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppliMeteo.Helper
{
    class NavigationService : INavigationService2
    {
        private readonly Dictionary<string, Type> pages = new Dictionary<string, Type>();
        private object currentPage;
        //interface de xmarin.forms proposant la quasi
        //totalité des méthodes reprises ici
        private INavigation navigation;

        public String CurrentPageKey
        {
            get
            {
                lock (pages)
                {
                    if (currentPage == null) return null;
                    var pageType = currentPage.GetType();
                    return pages.ContainsValue(pageType) ? pages.First(p => p.Value == pageType).Key : null;
                }
            }
        }

        public void GoBack()
        {
            navigation?.PopAsync();
        }


        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            NavigateTo(pageKey, parameter, true);
        }

        public void NavigateTo(string pageKey, object parameter, bool animate)
        {
            var page = getPage(pageKey, parameter);
            if (page != null) navigation?.PushAsync(page);
        }


        private Page getPage(string pageKey, object parameter)
        {
            lock (pages)
            {
                if (!pages.ContainsKey(pageKey))
                {
                    Debug.WriteLine($"Page inconnue: {pageKey}. NavigationService.Configure a-t-il été oublié ?", nameof(pageKey));
                    throw new ArgumentException(
                        $"Page inconnue: {pageKey}. NavigationService.Configure a-t-il été oublié ?", nameof(pageKey));
                }
                var type = pages[pageKey];
                ConstructorInfo constructor;
                object[] parameters;

                if (parameter == null)
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(c => !c.GetParameters().Any());

                    parameters = new object[] { };
                }
                else
                {
                    constructor = type.GetTypeInfo()
                        .DeclaredConstructors
                        .FirstOrDefault(
                            c =>
                            {
                                var p = c.GetParameters();
                                return p.Length == 1
                                       && p[0].ParameterType == parameter.GetType();
                            });

                    parameters = new[] { parameter };
                }

                if (constructor == null)
                {
                    throw new InvalidOperationException(
                        "Aucun constructeur approprié trouvé pour " + pageKey);
                }
                var page = constructor.Invoke(parameters) as Page;
                return page;
            }
        }

        public Task ModalNavigateTo(string pageKey)
        {
            return ModalNavigateTo(pageKey, null);
        }

        public Task ModalNavigateTo(string pageKey, object parameter, bool animate = true)
        {
            var page = getPage(pageKey, parameter);
            return page != null ? navigation?.PushModalAsync(page, animate) : Task.FromResult<Page>(null);
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (pages)
            {
                if (pages.ContainsKey(pageKey)) pages[pageKey] = pageType;
                else
                    pages.Add(pageKey, pageType);
            }
        }

        public Task ModalDismiss()
        {
            return navigation?.PopModalAsync();
        }

        //Je reçois MainPage au démarrage de l'application
        public void Initialize(Page navigationPage)
        {
            //Je demande la navigation contenue par MainPage 
            navigation = navigationPage.Navigation;
            currentPage = navigationPage;
        }
    }
}
