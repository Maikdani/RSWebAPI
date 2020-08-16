using System;
using System.Collections.Generic;
using System.Text;
using Web.API.Core.Interfaces;

namespace Web.API.Core.Entities
{
    public class Song : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public Artist Artist { get; set; }
        public string Shortname { get; set; }
        public int Bpm { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string SpotifyId { get; set; }
        public string Album { get; set; }
    }
}
