using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.API.Core.Entities;
using Web.API.Core.Interfaces;

namespace Web.API.Infrastructure.Data
{
    public class SongRepository : ISongRepository
    {
        private readonly DbContext _dbContext;

        public SongRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Song> AddAsync(Song entity)
        {
            this._dbContext.Set<Song>().Add(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddAllAsync(params Song[] entities)
        {
            this._dbContext.Set<Song>().AddRange(entities);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Song> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
            {
                return entity;
            }

            this._dbContext.Set<Song>().Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Song> GetAsync(int id)
        {
            return await this._dbContext.Set<Song>().FindAsync(id);
        }

        public async Task<Song> GetByNameAsync(string name)
        {
            return await this._dbContext.Set<Song>()
                .Where(x => x.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Song>> GetByGenreAsync(string genre)
        {
            return await this._dbContext.Set<Song>().Where(x => x.Genre.Equals(genre)).ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await this._dbContext.Set<Song>().ToListAsync();
        }

        public async Task UpdateAsync(Song entity)
        {
            this._dbContext.Set<Song>().Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }
    }
}
