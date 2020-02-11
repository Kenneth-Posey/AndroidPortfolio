using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.Models;
using TimeForChorein.Models.IModel;

namespace TimeForChorein.Services
{ 
    class ChoreService : IService<IChore>
    {
        SQLiteAsyncConnection _database;

        public ChoreService(SQLiteAsyncConnection database)
        {
            _database = database;
        }

        public async Task<IChore> GetById(int choreId)
        {
            return await _database.GetAsync<Chore>(x => x.ChoreId == choreId);
        }

        public async Task<IChore> Get(AsyncTableQuery<Chore> query)
        {
            return await _database.GetAsync<Chore>(query);
        }

        public async Task<int> Save(IChore chore)
        {
            if (await _database.Table<Chore>().CountAsync(x => x.ChoreId == chore.GetId()) == 0)
                return await _database.InsertAsync(chore);
            else
                return await _database.UpdateAsync(chore);
        }

        public async Task<int> Delete(IChore chore)
        {
            return await _database.DeleteAsync<Chore>(chore.GetId());
        }
    }
}
