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
        //
        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemon.OrderBy(p=>p.Id).ToList();
        }
    }
}
