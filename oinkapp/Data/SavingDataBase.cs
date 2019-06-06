using oinkapp.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oinkapp.Data
{
    public class SavingDatabase
    {
        readonly SQLiteAsyncConnection database;

        public SavingDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Saving>().Wait();

            //database.DropTableAsync<AhorroItem>();
        }

        public async Task<IList<Saving>> GetItemsAsync()
        {
            return await database.Table<Saving>().ToListAsync();
        }

        public async Task<Saving> GetItemAsync(int id)
        {
            var saving = await database.Table<Saving>().Where(i => i.Id == id).FirstOrDefaultAsync();
            if (saving == null)
            {
                saving = new Saving();
            }
            return saving;
        }

        public async Task<int> SaveItemAsync(Saving item)
        {
            if (item.Id != 0)
                return await database.UpdateAsync(item);

            return await database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(Saving item)
        {
            return await database.DeleteAsync(item);
        }
    }
}