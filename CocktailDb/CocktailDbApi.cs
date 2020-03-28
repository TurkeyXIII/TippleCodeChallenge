using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CocktailDb
{
    public class CocktailDbApi : ICocktailRepository
    {
        public async Task<List<int>> GetCocktailIdsByIngredient(string ingredient)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"https://www.thecocktaildb.com/api/json/v1/1/filter.php?i={ingredient}");

            string json = await responseMessage.Content.ReadAsStringAsync();

            List<Dtos.CocktailSummary> summaryDtos = JsonConvert.DeserializeObject<Dictionary<string, List<Dtos.CocktailSummary>>>(json)["drinks"];

            return summaryDtos.Select(s => s.IdDrink).ToList();
        }

        public async Task<Cocktail> GetCocktailById()
        {
            throw new NotImplementedException();
        }

        public async Task<Cocktail> GetRandomCocktail()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("https://www.thecocktaildb.com/api/json/v1/1/random.php");

            string json = await responseMessage.Content.ReadAsStringAsync();

            Dtos.Cocktail cocktailDto = JsonConvert.DeserializeObject<Dictionary<string, List<Dtos.Cocktail>>>(json)["drinks"][0];

            return new Cocktail
            {
                Id = cocktailDto.IdDrink,
                Name = cocktailDto.StrDrink,
                Instructions = cocktailDto.StrInstructions,
                ImageURL = cocktailDto.StrDrinkThumb,
                Ingredients = cocktailDto.Ingredients,
            };
        }
    }
}
