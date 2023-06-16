﻿

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonRevewApp.Dto;
using PokemonRevewApp.Interfaces;
using PokemonRevewApp.Models;

namespace PokemonRevewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IMapper mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            this.pokemonRepository = pokemonRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons =mapper.Map<List<PokemonDto>>( pokemonRepository.GetPokemons());
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(pokemons);
        }
        [HttpGet("{pokeId}")]
        [ProducesResponseType(200, Type=typeof(Pokemon))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemon(int pokeId) 
        {
            //Validation
            if(! pokemonRepository.PokemonExists(pokeId))
            {
                return NotFound();
            }
            var pokemon=mapper.Map<PokemonDto>(pokemonRepository.GetPokemon(pokeId));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(pokemon);

        }
        [HttpGet("{pokeId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonRating(int pokeId)
        {
            if(!pokemonRepository.PokemonExists(pokeId))
                return NotFound();
            var rating=pokemonRepository.GetPokemonRating(pokeId);

            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            return Ok(rating);
        }
    }   

}
