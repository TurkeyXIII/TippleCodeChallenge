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
                new Cocktail { Name = "abc", Id = 100 },
                new Cocktail { Name = "xyz", Id = 512 },
                new Cocktail { Name = "123", Id = 37 },
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
            CocktailList cocktailList = new CocktailList(_simpleList);

            Assert.AreEqual(37, cocktailList.meta.firstId);
            Assert.AreEqual(512, cocktailList.meta.lastId);
        }

        [TestMethod]
        public void MetadataHasCorrectMedianIngredient_Simple()
        {
            List<Cocktail> cocktailsWithIngredients = new List<Cocktail>
            {
                new Cocktail
                {
                    Ingredients = new List<string> { "1" },
                },
                new Cocktail
                {
                    Ingredients = new List<string> { "1", "2" },
                },
                new Cocktail
                {
                    Ingredients = new List<string> { "1", "2", "3" },
                }
            };

            CocktailList cocktailList = new CocktailList(cocktailsWithIngredients);

            Assert.AreEqual(2, cocktailList.meta.medianIngredientCount);
        }
    }
}
