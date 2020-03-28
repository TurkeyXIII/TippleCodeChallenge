using CocktailDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Tests.Api
{
    [TestClass]
    public class CocktailDbApiTests
    {
        [TestMethod]
        public async Task GetRandomCocktail_PopulatesId()
        {
            var api = new CocktailDbApi();
            
            var cocktail = await api.GetRandomCocktail();

            Assert.AreNotEqual(0, cocktail.Id);
        }

        [TestMethod]
        public async Task GetRandomCocktail_PopulatesStrings()
        {
            var api = new CocktailDbApi();

            var cocktail = await api.GetRandomCocktail();

            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.Name));
            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.Instructions));
            Assert.IsFalse(string.IsNullOrWhiteSpace(cocktail.ImageURL));
        }

        [TestMethod]
        public async Task GetRandomCocktail_PopulatesIngredientList()
        {
            var api = new CocktailDbApi();

            var cocktail = await api.GetRandomCocktail();

            Assert.IsTrue(cocktail.Ingredients.Count > 1);
            CollectionAssert.AllItemsAreNotNull(cocktail.Ingredients);
            CollectionAssert.AllItemsAreUnique(cocktail.Ingredients);
        }
    }
}
