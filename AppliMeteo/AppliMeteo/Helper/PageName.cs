using System;
using System.Collections.Generic;
using System.Text;

namespace AppliMeteo.Helper
{
    //L'enum reprend les noms de vues xaml (et behind) pour ne pas avoir, à partir du pattern mvvm, l'obligation de parcourir de vues dont le pattern n'est même pas supposé avoir consience.
    public enum PageName
    {
        MainPage,
        SecondPage
    }
}
