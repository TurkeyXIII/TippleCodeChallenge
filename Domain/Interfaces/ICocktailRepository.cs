using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICocktailRepository
    {
        Task<List<int>> GetCocktailIdsByIngredient(string ingredient);
        Task<Cocktail> GetCocktailById(int id);
        Task<Cocktail> GetRandomCocktail();

    }
}
