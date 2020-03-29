using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models.Response;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [Route("api")]
    [ApiController]
    public class BoozeController : ControllerBase
    {
        private readonly ICocktailService _cocktailService;

        public BoozeController(ICocktailService cocktailService)
        {
            _cocktailService = cocktailService;
        }
        
        [HttpGet]
        [Route("search-ingredient/{ingredient}")]
        public async Task<IActionResult> GetIngredientSearch([FromRoute] string ingredient)
        {
            var cocktailList = await _cocktailService.GetCocktailsByIngredient(ingredient);
            
            return Ok(cocktailList);
        }

        [HttpGet]
        [Route("random")]
        public async Task<IActionResult> GetRandom()
        {
            var cocktail = await _cocktailService.GetRandomCocktail();

            var model = new Cocktail(cocktail);
            return Ok(model);
        }
    }
}