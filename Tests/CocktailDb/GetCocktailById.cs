using CocktailDb;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests.CocktailDb
{
    [TestClass]
    public class GetCocktailById
    {
        [TestMethod]
        public async Task CorrectName()
        {
            var api = new CocktailDbApi();

            Cocktail cocktail = await api.GetCocktailById(15300);

            Assert.AreEqual("3-Mile Long Island Iced Tea", cocktail.Name);
        }

        [TestMethod]
        public async Task PopulatesIngredients()
        {
            var api = new CocktailDbApi();

            Cocktail cocktail = await api.GetCocktailById(13621);// Tequila sunrise

            Assert.AreEqual(3, cocktail.Ingredients.Count);
            CollectionAssert.AllItemsAreNotNull(cocktail.Ingredients);
            CollectionAssert.AllItemsAreUnique(cocktail.Ingredients);

            CollectionAssert.Contains(cocktail.Ingredients, "Tequila");
        }
    }
}
