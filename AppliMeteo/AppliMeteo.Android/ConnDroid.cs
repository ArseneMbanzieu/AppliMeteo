using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppliMeteo.DAL;
using AppliMeteo.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnDroid))]
namespace AppliMeteo.Droid
{
    class ConnDroid : ISqLite
    {
        public SQLiteConnection GetConnection(String databaseName)
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),databaseName);
            SQLiteConnection conn = new SQLiteConnection(path);
            return conn;
        }
    }
}