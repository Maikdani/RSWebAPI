using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Web.API.Core.Entities;

namespace Web.API.Infrastructure.Data
{
    public class DataSeeding
    {
        private readonly WebAPIContext _webAPIContext;

        public DataSeeding(WebAPIContext webAPIContext)
        {
            this._webAPIContext = webAPIContext;
        }

        public void AddSeedData(string appDataDirectory)
        {
            if (!this._webAPIContext.Song.Any())
            {
                var songs = new List<Song>();
                using (StreamReader r = new StreamReader(appDataDirectory + @"/AppData/songs.json"))
                {
                    string json = r.ReadToEnd();
                    songs = JsonConvert.DeserializeObject<List<Song>>(json);
                    songs = songs.Where(x => x.Genre.Contains("Metal") && x.Year < 2016).ToList();

                    this._webAPIContext.Song.AddRange(songs);

                    SaveChangesSeed("Song");
                }
            }

            // Voeg geen artiesten toe als er geen songs zijn anders weten we de eis "alle bands waarbij het genre “Metal” bevat" niet
            if (this._webAPIContext.Song.Any() && !this._webAPIContext.Artist.Any())
            {
                using (StreamReader r = new StreamReader(appDataDirectory + @"/AppData/artists.json"))
                {
                    string json = r.ReadToEnd();
                    var artists = JsonConvert.DeserializeObject<List<Artist>>(json);
                    artists = artists.GroupBy(x => x.Name)
                                     .Select(y => y.First())
                                     .Distinct()
                                     .ToList();

                    var artistsInSongs = this._webAPIContext.Song.Select(x => x.Artist).ToList();

                    // Voeg alleen de ariesten toe die metal in 1 van hun nummers hebben
                    artists = artists.Where(x => artistsInSongs.Contains(x.Name)).ToList();

                    this._webAPIContext.Artist.AddRange(artists);
                }
                SaveChangesSeed("Artist");
            }
        }

        private void SaveChangesSeed(string table)
        {
            this._webAPIContext.Database.OpenConnection();
            try
            {
                this._webAPIContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{table} ON");
                this._webAPIContext.SaveChanges();
                this._webAPIContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT dbo.{table} OFF");
            }
            finally
            {
                this._webAPIContext.Database.CloseConnection();
            }
        }
    }
}
