using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Entities;

namespace Web.API.Core.Interfaces
{
    public interface IArtistRepository
    {
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetAsync(int id);
        Task<Artist> GetByNameAsync(string name);
        Task<Artist> AddAsync(Artist entity);
        Task AddAllAsync(params Artist[] entities);
        Task UpdateAsync(Artist entity);
        Task<Artist> DeleteAsync(int id);
    }
}
