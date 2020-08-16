using AutoMapper;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Web.API.Core.DTOs;
using Web.API.Core.Entities;

namespace Web.API.Core.Profiles
{
    public class RockstarProfile : Profile
    {
        public RockstarProfile()
        {
            CreateMap<Artist, ArtistDTO>();
            CreateMap<ArtistDTO, Artist>();
            CreateMap<Song, SongDTO>();
            CreateMap<SongDTO, Song>();
        }
    }
}
