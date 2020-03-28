using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailDb.Dtos
{
    class Cocktail
    {
        public int IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }
    }
}
