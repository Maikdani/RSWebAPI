using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.DTOs;

namespace Web.API.Core.Interfaces
{
    public interface ISongService
    {
        Task<SongDTO> AddAsync(SongDTO song);
        Task<SongDTO> GetAsync(int id);
        Task<SongDTO> UpdateAsync(int id, SongDTO song);
        Task<SongDTO> DeleteAsync(int id);
        Task<IEnumerable<SongDTO>> GetAllAsync();
        Task<IEnumerable<SongDTO>> GetByGenreAsync(string genre);
    }
}
