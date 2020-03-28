using Business.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly ICocktailRepository _cocktailRepository;

        public CocktailService(ICocktailRepository cocktailRepository)
        {
            _cocktailRepository = cocktailRepository;
        }

        public async Task<Cocktail> GetRandomCocktail()
        {
            return await _cocktailRepository.GetRandomCocktail();
        }
    }
}
