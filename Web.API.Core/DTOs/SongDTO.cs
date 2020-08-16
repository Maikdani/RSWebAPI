using System;
using System.Collections.Generic;
using System.Text;

namespace Web.API.Core.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public ArtistDTO Artist { get; set; }
        public string Shortname { get; set; }
        public int Bpm { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string SpotifyId { get; set; }
        public string Album { get; set; }
    }
}
