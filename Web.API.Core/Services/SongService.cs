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
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository,
            IMapper mapper)
        {
            this._songRepository = songRepository;
            this._mapper = mapper;
        }

        public async Task<SongDTO> AddAsync(SongDTO songDTO)
        {
            try
            {
                songDTO.Id = 0;
                var song = this._mapper.Map<Song>(songDTO);

                if (await this._songRepository.GetByNameAsync(song.Name) != null)
                    return null;

                song = await this._songRepository.AddAsync(song);
                return this._mapper.Map<SongDTO>(song);
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<SongDTO> DeleteAsync(int id)
        {
            try
            {
                return this._mapper.Map<SongDTO>(await this._songRepository.DeleteAsync(id));
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<SongDTO> GetAsync(int id)
        {
            try
            {
                SongDTO song = this._mapper.Map<SongDTO>(await this._songRepository.GetAsync(id));
                return song;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SongDTO>> GetAllAsync()
        {
            var songs = await this._songRepository.GetAllAsync();
            return this._mapper.Map<IEnumerable<SongDTO>>(songs);
        }

        public async Task<SongDTO> UpdateAsync(int id, SongDTO songDTO)
        {
            try
            {
                var song = await this._songRepository.GetAsync(id);
                this._mapper.Map(songDTO, song);
                await this._songRepository.UpdateAsync(song);
                return songDTO;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<IEnumerable<SongDTO>> GetByGenreAsync(string genre)
        {
            var songs = await this._songRepository.GetByGenreAsync(genre);
            return this._mapper.Map<IEnumerable<SongDTO>>(songs);
        }
    }
}
