using CocktailDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests.CocktailDb
{
    [TestClass]
    public class GetCocktailIdsByIngredient
    {
        [TestMethod]
        public async Task ReturnsListOfIds()
        {
            var api = new CocktailDbApi();

            List<int> ids = await api.GetCocktailIdsByIngredient("Gin");

            Assert.IsTrue(ids.Count > 10);
            CollectionAssert.DoesNotContain(ids, 0);
            CollectionAssert.AllItemsAreUnique(ids);
        }
    }
}
