using api.Models.Response;
using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cocktail = Domain.Entities.Cocktail;

namespace Tests.Models
{
    [TestClass]
    public class CocktailListConstructor
    {
        private List<Cocktail> _simpleList;

        [TestInitialize]
        public void TestInitialize()
        {
            _simpleList = new List<Cocktail>
            {
                new Cocktail { Name = "abc" },
                new Cocktail { Name = "xyz" },
                new Cocktail { Name = "123" },
            };
        }

        [TestMethod]
        public void ListIsIncluded()
        {
            CocktailList cocktailList = new CocktailList(_simpleList);

            Assert.AreEqual(3, cocktailList.Cocktails.Count);

            var cocktailNames = cocktailList.Cocktails.Select(c => c.Name).ToList();
            CollectionAssert.Contains(cocktailNames, "abc");
            CollectionAssert.Contains(cocktailNames, "xyz");
            CollectionAssert.Contains(cocktailNames, "123");
        }

        [TestMethod]
        public void MetadataHasCorrectCount()
        {
            CocktailList cocktailList = new CocktailList(_simpleList);

            Assert.AreEqual(3, cocktailList.meta.count);
        }

        [TestMethod]
        public void MetadataHasCorrectIdRange()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MetadataHasCorrectMedianIngredient_Simple()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public void MetadataHasCorrectMedianIngredient_LargeVariation()
        {
            Assert.Inconclusive();
        }
    }
}
