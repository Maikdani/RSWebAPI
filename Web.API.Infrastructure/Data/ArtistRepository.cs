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
    public class ArtistRepository : IArtistRepository
    {
        private readonly DbContext _dbContext;

        public ArtistRepository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Artist> AddAsync(Artist entity)
        {
            this._dbContext.Set<Artist>().Add(entity);
            await this._dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task AddAllAsync(params Artist[] entities)
        {
            this._dbContext.Set<Artist>().AddRange(entities);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Artist> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            if (entity == null)
            {
                return entity;
            }

            this._dbContext.Set<Artist>().Remove(entity);
            await this._dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<Artist> GetAsync(int id)
        {
            return await this._dbContext.Set<Artist>().FindAsync(id);
        }

        public async Task<Artist> GetByNameAsync(string name)
        {
            return await this._dbContext.Set<Artist>()
                .Where(x => x.Name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await this._dbContext.Set<Artist>().ToListAsync();
        }

        public async Task UpdateAsync(Artist entity)
        {
            this._dbContext.Set<Artist>().Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
            await this._dbContext.SaveChangesAsync();
        }
    }
}
