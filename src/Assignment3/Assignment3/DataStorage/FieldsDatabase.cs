using Assignment3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.DataStorage
{
    public class FeildDatabase
    {
        readonly SQLiteAsyncConnection database;

        public FeildDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<FormFields>().Wait();
        }

        public Task<List<FormFields>> GetFieldsAsync()
        {
            return database.Table<FormFields>().ToListAsync();
        }

        public Task<FormFields> GetFieldsAsync(int id)
        {
            return database.Table<FormFields>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveFieldsAsync(FormFields field)
        {
            if (field.Id != 0)
            {
                return database.UpdateAsync(field);
            }
            else
            {
                return database.InsertAsync(field);
            }
        }

        public Task<int> DeleteFieldsAsync(FormFields field)
        {
            return database.DeleteAsync(field);
        }
    }
}
