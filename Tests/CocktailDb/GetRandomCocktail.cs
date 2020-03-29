using CocktailDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Tests.CocktailDb
{
    [TestClass]
    public class GetRandomCocktail
    {
        [TestMethod]
        public async Task PopulatesId()
        {
            var api = new CocktailDbApi();
            
            var cocktail = await api.GetRandomCocktail();

            Assert.AreNotEqual(0, cocktail.Id);
        }

        [TestMethod]
        public async Task PopulatesStrings()
        {
            var api = new CocktailDbApi();

            var cocktail = await api.GetRandomCocktail();

            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.Instructions));
            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.ImageURL));
        }

        [TestMethod]
        public async Task PopulatesIngredientList()
        {
            var api = new CocktailDbApi();

            var cocktail = await api.GetRandomCocktail();

            Assert.IsTrue(cocktail.Ingredients.Count > 1);
            CollectionAssert.AllItemsAreNotNull(cocktail.Ingredients);
            CollectionAssert.AllItemsAreUnique(cocktail.Ingredients);
        }
    }
}
