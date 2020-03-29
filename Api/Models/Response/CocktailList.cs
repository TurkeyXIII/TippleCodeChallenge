using Business.Utility;
using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Models.Response
{
    public class CocktailList
    {
        public CocktailList(List<Domain.Entities.Cocktail> cocktails)
        {
            Cocktails = cocktails.Select(x => new Cocktail(x)).ToList();

            meta = new ListMeta(cocktails);
        }

        public List<Cocktail> Cocktails { get; set; }
        public ListMeta meta { get; set; }
    }

    public class ListMeta
    {
        public ListMeta(List<Domain.Entities.Cocktail> cocktails)
        {
            count = cocktails.Count;
            firstId = cocktails.Min(c => c.Id);
            lastId = cocktails.Max(c => c.Id);

            var ingredientCounts = cocktails.Select(c => c.Ingredients != null ? c.Ingredients.Count : 0);
            medianIngredientCount = Set.Median(ingredientCounts);
        }

        public int count { get; set; }
        public int firstId { get; set; }
        public int lastId { get; set; }
        public int medianIngredientCount { get; set; }
    }
}