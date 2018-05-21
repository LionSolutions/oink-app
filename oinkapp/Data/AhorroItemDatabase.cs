using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using oinkapp.Model;
using SQLite;

namespace oinkapp.Data
{
    public class AhorroItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public AhorroItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<AhorroItem>().Wait();
        }

        public Task<List<AhorroItem>> GetItemsAsync()
        {
            return database.Table<AhorroItem>()
                           .Where(element => !element.EsCompra)
                           .ToListAsync();
        }

        public Task<AhorroItem> GetItemAsync(int id)
        {
            return database.Table<AhorroItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(AhorroItem item)
        {
            if (item.Id != 0)
                return database.UpdateAsync(item);
            else
                return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(AhorroItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}