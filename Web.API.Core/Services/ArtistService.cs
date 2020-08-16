using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.DTOs;
using Web.API.Core.Entities;
using Web.API.Core.Interfaces;

namespace Web.API.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IRepository<Artist> artistRepository,
            IMapper mapper)
        {
            this._artistRepository = artistRepository;
            this._mapper = mapper;
        }

        public async Task<ArtistDTO> AddAsync(ArtistDTO artistDTO)
        {
            try
            {
                // Logic voor dubbele naam hier toevoegen
                var artist = this._mapper.Map<Artist>(artistDTO);
                artist = await this._artistRepository.AddAsync(artist);
                return this._mapper.Map<ArtistDTO>(artist);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<ArtistDTO> DeleteAsync(int id)
        {
            try
            {
                return this._mapper.Map<ArtistDTO>(await this._artistRepository.DeleteAsync(id));
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<ArtistDTO> GetAsync(int id)
        {
            try
            {
                ArtistDTO artist = this._mapper.Map<ArtistDTO>(await this._artistRepository.GetAsync(id));
                return artist;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllAsync()
        {
            var artists = await this._artistRepository.GetAllAsync();
            return this._mapper.Map<IEnumerable<ArtistDTO>>(artists);
        }

        public async Task<ArtistDTO> UpdateAsync(int id, ArtistDTO artistDTO)
        {
            try
            {
                var artist = await this._artistRepository.GetAsync(id);
                this._mapper.Map(artistDTO, artist);
                await this._artistRepository.UpdateAsync(artist);
                return artistDTO;
            }
            catch (Exception exception)
            {
                return null;
            }
        }
    }
}
