using oinkapp.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oinkapp.Data
{
    public class TargetDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TargetDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Target>().Wait();

            //  database.DropTableAsync<DeseoItem>();
        }

        public async Task<IList<Target>> GetItemsAsync()
        {
            return await database.Table<Target>().ToListAsync();
        }

        public async Task<Target> GetItemAsync(int id)
        {
            return await database.Table<Target>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(Target item)
        {
            if (item.Id != 0)
                return await database.UpdateAsync(item);

            return await database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(Target item)
        {
            return database.DeleteAsync(item);
        }
    }
}