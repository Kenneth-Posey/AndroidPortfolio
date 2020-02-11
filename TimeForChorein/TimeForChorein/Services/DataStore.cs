using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TimeForChorein.Models;

namespace TimeForChorein.Services
{
    public class DataStore
    {
        readonly SQLiteAsyncConnection _database;

        public DataStore(string path)
        {
            _database = new SQLiteAsyncConnection(path);

            // CreateTableAsync does not recreate the table if it exists
            _database.CreateTableAsync<Chore>();
        }
    }
}
