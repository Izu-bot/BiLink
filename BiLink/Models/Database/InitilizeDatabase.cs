using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiLink.Models.Database
{
    internal class InitilizeDatabase
    {
        private static SQLiteAsyncConnection? _database;

        public InitilizeDatabase(SQLiteAsyncConnection database) => _database = database;

        public static SQLiteAsyncConnection GetConnection()
        {
            if (_database == null)
            {
                throw new InvalidOperationException("Banco de dados não inicializado. Chame Initilize() primeiro.");
            }
            return _database;
        }
    }
}
