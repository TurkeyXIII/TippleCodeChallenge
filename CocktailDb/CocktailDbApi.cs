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
        private const string uri = @"https://www.thecocktaildb.com/api/json/v1/1/";

        public async Task<List<int>> GetCocktailIdsByIngredient(string ingredient)
        {
            List<Dtos.CocktailSummary> summaryDtos = await GetByPath<Dtos.CocktailSummary>($"filter.php?i={ingredient}");

            return summaryDtos.Select(s => s.IdDrink).ToList();
        }

        private async Task<List<T>> GetByPath<T>(string path)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync(uri + path);

            string json = await responseMessage.Content.ReadAsStringAsync();

            List<T> summaryDtos = JsonConvert.DeserializeObject<Dictionary<string, List<T>>>(json)["drinks"];

            return summaryDtos;
        }

        public async Task<Cocktail> GetCocktailById(int id)
        {
            Dtos.Cocktail cocktailDto = (await GetByPath<Dtos.Cocktail>($"lookup.php?i={id}"))[0];

            return MapCocktailDtoOntoDomainObject(cocktailDto);
        }

        private Cocktail MapCocktailDtoOntoDomainObject(Dtos.Cocktail cocktailDto)
        {
            return new Cocktail
            {
                Id = cocktailDto.IdDrink,
                Name = cocktailDto.StrDrink,
                Instructions = cocktailDto.StrInstructions,
                ImageURL = cocktailDto.StrDrinkThumb,
                Ingredients = cocktailDto.Ingredients,
            };
        }

        public async Task<Cocktail> GetRandomCocktail()
        {
            Dtos.Cocktail cocktailDto = (await GetByPath<Dtos.Cocktail>("random.php"))[0];

            return MapCocktailDtoOntoDomainObject(cocktailDto);
        }
    }
}
