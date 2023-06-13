using PokemonRevewApp.Models;

namespace PokemonRevewApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();

    }
}
