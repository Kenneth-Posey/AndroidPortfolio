using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeForChorein.Models;
using TimeForChorein.Models.IModel;

namespace TimeForChorein.Services
{ 
    public class ChoreService : IService<IChore>
    {
        SQLiteAsyncConnection _dataConnection;

        public ChoreService()
        {
            _dataConnection = App.Database.GetConnection();
        }

        public async Task<IChore> GetById(int? choreId)
        {
            return await _dataConnection.GetAsync<Chore>(x => x.ChoreId == choreId);
        }

        public async Task<IEnumerable<IChore>> GetAllChores()
        {
            return await _dataConnection.Table<Chore>().Where(x => x.ChoreStatus != Enums.ChoreStatus.Deleted).ToListAsync();
        }

        public async Task<IChore> Get(IQueryable query)
        {
            return await _dataConnection.GetAsync<Chore>(query);
        }

        public async Task<int> Save(IChore chore)
        {
            var id = (chore as Chore).GetId();
            if (await _dataConnection.Table<Chore>().CountAsync(x => x.ChoreId == id) == 0)
                return await _dataConnection.InsertAsync(chore);
            else
                return await _dataConnection.UpdateAsync(chore);
        }

        public async Task<int> Delete(IChore chore)
        {
            return await _dataConnection.DeleteAsync<Chore>(chore.GetId());
        }
    }
}
