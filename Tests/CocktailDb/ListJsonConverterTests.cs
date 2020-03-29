using CocktailDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests.CocktailDb
{
    [TestClass]
    public class ListJsonConverterTests
    {
        [TestMethod]
        public void Deserialize_NormalString()
        {
            var input = new InputObject
            {
                NormalString = "abc",
            };
            string json = JsonConvert.SerializeObject(input);

            var result = JsonConvert.DeserializeObject<ResultObject>(json, new ListJsonConverter());

            Assert.AreEqual(input.NormalString, result.NormalString);
        }

        [TestMethod]
        public void Deserialize_StringInListOfOne()
        {
            var input = new InputObject
            {
                ListOfOneString1 = "abc",
            };
            string json = JsonConvert.SerializeObject(input);

            var result = JsonConvert.DeserializeObject<ResultObject>(json, new ListJsonConverter());

            Assert.AreEqual(1, result.ListOfOneString.Count);
            Assert.AreEqual(input.ListOfOneString1, result.ListOfOneString.Single());
        }

        [TestMethod]
        public void Deserialize_StringInListOfMany()
        {
            var input = new InputObject
            {
                ListOfManyStrings1 = "abc",
                ListOfManyStrings2 = "xyz",
                ListOfManyStrings3 = "123",
            };
            string json = JsonConvert.SerializeObject(input);

            var result = JsonConvert.DeserializeObject<ResultObject>(json, new ListJsonConverter());

            Assert.AreEqual(3, result.ListOfManyStrings.Count);

            CollectionAssert.Contains(result.ListOfManyStrings, input.ListOfManyStrings1);
            CollectionAssert.Contains(result.ListOfManyStrings, input.ListOfManyStrings2);
            CollectionAssert.Contains(result.ListOfManyStrings, input.ListOfManyStrings3);
        }

        [TestMethod]
        public void Deserialize_ListIsInChildObject()
        {
            var input = new Dictionary<string, List<InputObject>>
            {
                {
                    "test",
                    new List<InputObject>
                    {
                        new InputObject
                        {
                        ListOfManyStrings1 = "abc",
                        ListOfManyStrings2 = "xyz",
                        ListOfManyStrings3 = "123",
                        }
                    }
                }
            };
            string json = JsonConvert.SerializeObject(input);

            var result = JsonConvert.DeserializeObject<Dictionary<string, List<ResultObject>>>(json, new ListJsonConverter());

            Assert.AreEqual(3, result["test"][0].ListOfManyStrings.Count);

            CollectionAssert.Contains(result["test"][0].ListOfManyStrings, input["test"][0].ListOfManyStrings1);
            CollectionAssert.Contains(result["test"][0].ListOfManyStrings, input["test"][0].ListOfManyStrings2);
            CollectionAssert.Contains(result["test"][0].ListOfManyStrings, input["test"][0].ListOfManyStrings3);
        }
    }

    internal class InputObject
    {
        public string NormalString { get; set; }

        public string ListOfOneString1 { get; set; }

        public string ListOfManyStrings1 { get; set; }
        public string ListOfManyStrings2 { get; set; }
        public string ListOfManyStrings3 { get; set; }
    }

    internal class ResultObject
    {
        public string NormalString { get; set; }
        public List<string> ListOfOneString { get; set; }
        public List<string> ListOfManyStrings { get; set; }
    }
}
