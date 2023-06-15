

using Microsoft.AspNetCore.Mvc;
using PokemonRevewApp.Interfaces;
using PokemonRevewApp.Models;

namespace PokemonRevewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;

        public PokemonController(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type=typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = pokemonRepository.GetPokemons();
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
            var pokemon=pokemonRepository.GetPokemon(pokeId);
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
