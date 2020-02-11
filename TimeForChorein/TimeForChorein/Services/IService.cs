using System.Threading.Tasks;
using TimeForChorein.Models;

namespace TimeForChorein.Services
{
    public interface IService<T>
        where T : IEntity
    {
        Task<T> GetById(int id);

        Task<int> Save(T entity);

        Task<int> Delete(T entity);
    }
}