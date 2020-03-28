using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailDb.Dtos
{
    class Cocktail
    {
        public int IdDrink { get; set; }
        public string StrDrink { get; set; }
        public string StrInstructions { get; set; }
        public string StrDrinkThumb { get; set; }


        public string StrIngredient1 { get; set; }
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }

        public List<string> Ingredients
        {
            get
            {
                var ingredients = new List<string>
                {
                    StrIngredient1,
                    StrIngredient2,
                    StrIngredient3,
                    StrIngredient4,
                    StrIngredient5,
                    StrIngredient6,
                    StrIngredient7,
                    StrIngredient8,
                    StrIngredient9,
                    StrIngredient10,
                    StrIngredient11,
                    StrIngredient12,
                    StrIngredient13,
                    StrIngredient14,
                    StrIngredient15,
                };

                ingredients = ingredients.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

                return ingredients;
            }
        }
    }
}
