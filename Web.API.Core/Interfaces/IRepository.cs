using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Core.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddAllAsync(params TEntity[] entities);
        Task UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);
    }
}
