using PokemonRevewApp.Models;

namespace PokemonRevewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category>GetCategories();
        Category GetCategory(int id);
        ICollection<Pokemon> GetPokemonByCategory(int categoryId);
        bool CategoryExists(int id);

    }
}
