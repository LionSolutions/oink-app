using oinkapp.Helpers;
using oinkapp.Interfaces;
using oinkapp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace oinkapp.Data
{
    public class SavingDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly string nameOfDatabase;

        public SavingDatabase()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();
            nameOfDatabase = fileHelper.GetLocalFilePath(KeysHelper.SavingDatabaseName);

            database = new SQLiteAsyncConnection(nameOfDatabase);
            database.CreateTableAsync<Saving>().Wait();
        }

        public async Task<IList<Saving>> GetItemsAsync()
        {
            try
            {
                return await database.Table<Saving>().ToListAsync();
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        internal async Task<bool> AddSavings(List<Saving> savings)
        {
            try
            {
                foreach (var saving in savings)
                {
                    await database.InsertAsync(saving);
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Saving> GetItemAsync(int id)
        {
            try
            {
                var saving = await database.Table<Saving>().Where(i => i.Id == id).FirstOrDefaultAsync();
                if (saving == null)
                {
                    saving = new Saving();
                }
                return saving;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<int> SaveItemAsync(Saving item)
        {
            try
            {
                if (item.Id != 0)
                    return await database.UpdateAsync(item);

                return await database.InsertAsync(item);
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<int> DeleteItemAsync(Saving item)
        {
            try
            {
                return await database.DeleteAsync(item);
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> RestoreDatabase()
        {
            try
            {
                await database.DropTableAsync<Saving>();
                database.CreateTableAsync<Saving>().Wait();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}