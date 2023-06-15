using PokemonRevewApp.Data;
using PokemonRevewApp.Interfaces;
using PokemonRevewApp.Models;

namespace PokemonRevewApp.Repository
{

    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext context;

        public PokemonRepository(DataContext context)
        {
            this.context = context;
        }

        public Pokemon GetPokemon(int id)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemon(string name)
        {
            throw new NotImplementedException();
        }

        public decimal GetPokemonRating(int pokeId)
        {
            throw new NotImplementedException();
        }

        //
        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemon.OrderBy(p=>p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            throw new NotImplementedException();
        }
    }
}
