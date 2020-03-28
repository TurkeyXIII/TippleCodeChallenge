using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICocktailRepository
    {
        Task<Cocktail> GetRandomCocktail();
    }
}
