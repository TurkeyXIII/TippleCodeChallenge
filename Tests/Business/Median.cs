using Business.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Business
{
    [TestClass]
    public class Median
    {
        [TestMethod]
        public void SimpleSetOfThree()
        {
            var set = new List<int> { 1, 2, 3 };

            int result = Set.Median(set);

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ManyWithSameValue()
        {
            var set = new List<int> { 1, 1, 1, 1, 6 };

            int result = Set.Median(set);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void EvenNumberOfItems()
        {
            var set = new List<int> { 2, 9 };

            int result = Set.Median(set);

            Assert.AreEqual((int)5.5, result);
        }
    }
}
