using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using oinkapp.Model;
using SQLite;

namespace oinkapp.Data
{
    public class UsuarioItemDataBase
    {
        readonly SQLiteAsyncConnection database;

        public UsuarioItemDataBase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Usuario>().Wait();

            //  database.DropTableAsync<Usuario>();
        }

        public Task<Usuario> GetItemAsync(string _correo, string _clave)
        {
            return database.Table<Usuario>().Where(i => i.Correo == _correo && i.Clave == _clave).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Usuario item)
        {
            if (item.Id != 0)
                return database.UpdateAsync(item);
            else
                return database.InsertAsync(item);
        }
    }
}