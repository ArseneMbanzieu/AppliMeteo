using AppliMeteo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppliMeteo.DAL
{
    public class Connector : IDisposable
    {
        private const string databaseName = "DB.sqlite";
        private static readonly object locker = new object();

        public Connector(bool init)
        {
            if (init) OpenConnection();
        }

        private SQLiteConnection OpenConnection()
        {
            SQLiteConnection conn = DependencyService.Get<ISqLite>().GetConnection(databaseName);
            var info = conn.GetTableInfo("VilleRoot");
            if (!info.Any())
            {
                conn.CreateTable<VilleRoot>();
                IEnumerable<VilleRoot> temp;

                using (var repo = new APIRecuperator())
                {
                    temp = repo.GetVilles().Result;
                }

                foreach (var item in temp)
                {
                    conn.Insert(item);
                }
            }
            return conn;
        }

        public Task<bool> IsCityExisting(string s)
        {
            return Task.Run(() =>
            {
                lock (locker)
                {
                    using (var db = OpenConnection())
                    {
                        return db.Table<VilleRoot>().Any(x => x.url == s.ToLower());
                    }
                }
            });
        }

        public void Dispose()
        {

        }
    }
}
