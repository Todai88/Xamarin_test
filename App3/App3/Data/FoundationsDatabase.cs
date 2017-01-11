using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace App3
{
    public class FoundationsDatabase
    {

        readonly SQLiteAsyncConnection db;

        public FoundationsDatabase(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Foundation>().Wait();
        }

        public Task<List<Foundation>> GetItemsAsync()
        {
            return db.Table<Foundation>().ToListAsync();
        }

        public Task<List<Foundation>> GetItemsAsync(int id)
        {
             
            return db.Table<Foundation>().Where(i => i.ID == id).ToListAsync();

        }

        public Task<int> SaveItemAsync(Foundation item)
        {
            if (item.ID != 0){
                return db.UpdateAsync(item);
            } else{
                return db.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Foundation item){
            return db.DeleteAsync(item);
        }
    }
}
