using CocktailDb.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace CocktailDb
{
    public class ListJsonConverter : JsonConverter
    {
        private Regex partOfAListRegex = new Regex(@"^(?<ListName>.*)[0-9]+$");

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);

            item = AddPropertiesRecursive(item, item.Root);

            return item.ToObject(objectType, JsonSerializer.CreateDefault());
        }

        private JObject AddPropertiesRecursive(JObject item, JToken currentToken)
        {
            if (currentToken.Type == JTokenType.Property && currentToken.Children().Count() == 1)
            {
                item = AddPropertiesRecursive(item, currentToken.Children().Single());
            }

            if (currentToken.Type == JTokenType.Array)
            {
                foreach (var child in currentToken.Children())
                {
                    item = AddPropertiesRecursive(item, child);
                }
            }

            if (currentToken.Type == JTokenType.Object)
            {
                JObject jObject = currentToken as JObject;

                foreach (var child in currentToken.Children<JProperty>())
                {
                    var grandChildren = child.Children();
                    if (grandChildren.Count() == 1)
                        item = AddPropertiesRecursive(item, grandChildren.Single());
                }

                var stringProperties = jObject.Children<JProperty>();

                var propertiesDictionary = jObject.Children<JProperty>().ToDictionary(p => p.Name, p => p.Value.ToString());

                var propertyNamesGroupedByListName = propertiesDictionary.Keys.Where(n => partOfAListRegex.IsMatch(n))
                    .GroupBy(n => partOfAListRegex.Match(n).Groups["ListName"].Value, n => n);

                foreach (IGrouping<string, string> group in propertyNamesGroupedByListName)
                {
                    List<string> sourcePropertyNames = group.ToList();
                    List<string> newPropertyValue = new List<string>();
                    string newPropertyName = group.Key;

                    foreach (var sourcePropertyName in sourcePropertyNames)
                    {
                        newPropertyValue.Add(propertiesDictionary[sourcePropertyName]);
                    }

                    jObject.Add(newPropertyName, JToken.FromObject(newPropertyValue));
                }
            }

            return item;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }
}
