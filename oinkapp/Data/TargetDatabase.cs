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
    public class TargetDatabase
    {
        readonly SQLiteAsyncConnection database;
        readonly string nameOfDatabase;

        public TargetDatabase()
        {
            var fileHelper = DependencyService.Get<IFileHelper>();
            nameOfDatabase = fileHelper.GetLocalFilePath(KeysHelper.TargetDatabaseName);

            database = new SQLiteAsyncConnection(nameOfDatabase);
            database.CreateTableAsync<Target>().Wait();
        }

        public async Task<IList<Target>> GetItemsAsync()
        {
            try
            {
                return await database.Table<Target>().ToListAsync();
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        internal async Task<bool> AddTargets(List<Target> targets)
        {
            try
            {
                foreach (var target in targets)
                {
                    await database.InsertAsync(target);
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<Target> GetItemAsync(int id)
        {
            try
            {
                var Target = await database.Table<Target>().Where(i => i.Id == id).FirstOrDefaultAsync();
                if (Target == null)
                {
                    Target = new Target();
                }
                return Target;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<int> SaveItemAsync(Target item)
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

        public async Task<int> DeleteItemAsync(Target item)
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
                await database.DropTableAsync<Target>();
                database.CreateTableAsync<Target>().Wait();
                return true;
            }
            catch (SQLiteException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}