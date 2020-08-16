using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Entities;

namespace Web.API.Core.Interfaces
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetAllAsync();
        Task<Song> GetAsync(int id);
        Task<IEnumerable<Song>> GetByGenreAsync(string genre);
        Task<Song> GetByNameAsync(string name);
        Task<Song> AddAsync(Song entity);
        Task AddAllAsync(params Song[] entities);
        Task UpdateAsync(Song entity);
        Task<Song> DeleteAsync(int id);
    }
}
