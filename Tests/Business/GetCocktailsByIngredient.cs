using Business.Interfaces;
using Business.Services;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Business
{
    [TestClass]
    public class GetCocktailsByIngredient
    {
        private Mock<ICocktailRepository> _repositoryMock;
        private ICocktailService Service => new CocktailService(_repositoryMock.Object);

        [TestInitialize]
        public void TestInitialize()
        {
            _repositoryMock = new Mock<ICocktailRepository>();
        }

        [TestMethod]
        public async Task EveryCocktailIsReturned()
        {
            _repositoryMock.Setup(r => r.GetCocktailIdsByIngredient(It.IsAny<string>()))
                .ReturnsAsync(new List<int>
                {
                    1,
                    2,
                    3,
                });

            _repositoryMock.Setup(r => r.GetCocktailById(1))
                .ReturnsAsync(new Cocktail
                {
                    Name = "abc",
                });

            _repositoryMock.Setup(r => r.GetCocktailById(2))
                .ReturnsAsync(new Cocktail
                {
                    Name = "xyz",
                });

            _repositoryMock.Setup(r => r.GetCocktailById(3))
                .ReturnsAsync(new Cocktail
                {
                    Name = "123",
                });

            var cocktails = await Service.GetCocktailsByIngredient("test");

            Assert.AreEqual(3, cocktails.Count);

            var cocktailNames = cocktails.Select(c => c.Name).ToList();
            CollectionAssert.Contains(cocktailNames, "abc");
            CollectionAssert.Contains(cocktailNames, "xyz");
            CollectionAssert.Contains(cocktailNames, "123");
        }
    }
}
