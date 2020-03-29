using Business.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
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

        public async Task<List<Cocktail>> GetCocktailsByIngredient(string ingredient)
        {
            var ids = await _cocktailRepository.GetCocktailIdsByIngredient(ingredient);

            var cocktails = new List<Cocktail>(ids.Count);
            foreach (var id in ids)
            {
                var cocktail = await _cocktailRepository.GetCocktailById(id);
                cocktails.Add(cocktail);
            }

            return cocktails;
        }

        public async Task<Cocktail> GetRandomCocktail()
        {
            return await _cocktailRepository.GetRandomCocktail();
        }
    }
}
