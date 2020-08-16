using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.API.Core.DTOs;
using Web.API.Core.Entities;
using Web.API.Core.Interfaces;
using Web.API.Infrastructure.Data;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            this._songService = songService;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<IEnumerable<SongDTO>> GetSong()
        {
            return await this._songService.GetAllAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SongDTO>> GetSong(int id)
        {
            var song = await this._songService.GetAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // GET: api/Songs/5
        [HttpGet("{genre}")]
        public async Task<IEnumerable<SongDTO>> GetSongsByGenre(string genre)
        {
            return await this._songService.GetByGenreAsync(genre);
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(int id, SongDTO song)
        {
            if (ModelState.IsValid)
            {
                if (id != song.Id)
                {
                    return BadRequest();
                }

                try
                {
                    await this._songService.UpdateAsync(id, song);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SongExistsAsync(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Songs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SongDTO>> PostSong(SongDTO song)
        {
            if (ModelState.IsValid)
            {
                song = await this._songService.AddAsync(song);

                if (song == null)
                {
                    return BadRequest();
                }
                return song;
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SongDTO>> DeleteSong(int id)
        {
            var song = await this._songService.DeleteAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        private async Task<bool> SongExistsAsync(int id)
        {
            return await this._songService.GetAsync(id) != null;
        }
    }
}
