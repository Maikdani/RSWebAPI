using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Web.API.Infrastructure.Data;
using AutoMapper;
using Web.API.Core.Profiles;
using Web.API.Core.Interfaces;
using Web.API.Core.Services;
using Web.API.Core.Entities;

namespace Web.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<WebAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebAPIContext")));

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IRepository<Artist>, ArtistRepository>();
            services.AddScoped<ArtistRepository>();
            services.AddScoped<DbContext, WebAPIContext>();

            services.AddAutoMapper(c => c.AddProfile<RockstarProfile>(), typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
