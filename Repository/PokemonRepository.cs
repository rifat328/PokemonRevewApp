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
            return context.Pokemon.Where(p => p.Id == id).FirstOrDefault();  
        }

        public Pokemon GetPokemon(string name)
        {
            return context.Pokemon.Where(p => p.Name == name).FirstOrDefault();

        }

        public decimal GetPokemonRating(int pokeId)
        {
            var review = context.Reviews.Where(p => p.Pokemon.Id == pokeId);

            if (review.Count() <= 0)
                return 0;
            return ((decimal)review.Sum(r => r.Rating) / review.Count());
            // (decimal) called conversion
        }

        //
        public ICollection<Pokemon> GetPokemons()
        {
            return context.Pokemon.OrderBy(p=>p.Id).ToList();
        }

        public bool PokemonExists(int pokeId)
        {
            return context.Pokemon.Any(p => p.Id == pokeId);
        }
    }
}
