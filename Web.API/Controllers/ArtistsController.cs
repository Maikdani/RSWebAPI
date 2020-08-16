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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            this._artistService = artistService;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<IEnumerable<ArtistDTO>> GetArtist()
        {
            return await this._artistService.GetAllAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistDTO>> GetArtist(int id)
        {
            var artist = await this._artistService.GetAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, ArtistDTO artist)
        {
            if (id != artist.Id)
            {
                return BadRequest();
            }

            try
            {
                await this._artistService.UpdateAsync(id, artist);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ArtistExistsAsync(id))
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

        // POST: api/Artists
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ArtistDTO>> PostArtist(ArtistDTO artist)
        {
            artist = await this._artistService.AddAsync(artist);
            return artist;
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ArtistDTO>> DeleteArtist(int id)
        {
            var artist = await this._artistService.DeleteAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        private async Task<bool> ArtistExistsAsync(int id)
        {
            return await this._artistService.GetAsync(id) != null;
        }
    }
}
