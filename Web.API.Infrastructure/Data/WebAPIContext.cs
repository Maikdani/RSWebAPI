using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.API.Core.Entities;

namespace Web.API.Infrastructure.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artist { get; set; }
        public DbSet<Song> Song { get; set; }
    }
}
