using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.DTOs;

namespace Web.API.Core.Interfaces
{
    public interface IArtistService
    {
        Task<ArtistDTO> AddAsync(ArtistDTO artist);
        Task<ArtistDTO> GetAsync(int id);
        Task<ArtistDTO> UpdateAsync(int id, ArtistDTO artist);
        Task<ArtistDTO> DeleteAsync(int id);
        Task<IEnumerable<ArtistDTO>> GetAllAsync();
    }
}
