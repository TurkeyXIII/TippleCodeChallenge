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
        }

        public int count { get; set; }    // number of results
        public int firstId { get; set; }    // smallest Id of the results
        public int lastId { get; set; }    // largest Id of the results
        public int medianIngredientCount { get; set; }    // median of the number of ingredients per cocktail
    }
}