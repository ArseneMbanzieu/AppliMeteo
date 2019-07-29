using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppliMeteo.DAL
{
    public interface ISqLite
    {
        SQLiteConnection GetConnection(string databaseName);
    }
}
