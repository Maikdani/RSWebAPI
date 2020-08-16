using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Web.API.Core.DTOs
{
    public class SongDTO
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Range(1900, 2021)]
        public int Year { get; set; }
        [Required, MaxLength(50)]
        public string Artist { get; set; }
        [Required, MaxLength(50)]
        public string Shortname { get; set; }
        public int? Bpm { get; set; }
        public int Duration { get; set; }
        [Required, MaxLength(50)]
        public string Genre { get; set; }
        public string SpotifyId { get; set; }
        public string Album { get; set; }
    }
}
