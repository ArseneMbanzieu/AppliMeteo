using AppliMeteo.DAL;
using AppliMeteo.UWP;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly:Dependency(typeof(ConnUWP))]
namespace AppliMeteo.UWP
{
    class ConnUWP : ISqLite
    {
        public SQLiteConnection GetConnection(String databaseName)
        {
            var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, databaseName);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}
