using AutoMapper;
using PokemonRevewApp.Dto;
using PokemonRevewApp.Models;

namespace PokemonRevewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() {
            CreateMap<Pokemon, PokemonDto>(); //  youtube time stamp : https://youtu.be/K4WuxwkXrIY?t=1615
        }
    }
}
