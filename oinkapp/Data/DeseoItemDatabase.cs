using oinkapp.Model;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oinkapp.Data
{
    public class DeseoItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public DeseoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<DeseoItem>().Wait();

            //  database.DropTableAsync<DeseoItem>();
        }

        public Task<List<DeseoItem>> GetItemsAsync()
        {
            return database.Table<DeseoItem>().ToListAsync();
        }

        public Task<DeseoItem> GetItemAsync(int id)
        {
            return database.Table<DeseoItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DeseoItem item)
        {
            if (item.Id != 0)
                return database.UpdateAsync(item);
            else
                return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(DeseoItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}