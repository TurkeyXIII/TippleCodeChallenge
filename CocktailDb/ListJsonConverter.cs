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
            if (reader.TokenType == JsonToken.StartObject)
            {
                JObject item = JObject.Load(reader);

                var propertyNames = item.Properties().Select(p => p.Name);

                var propertyNamesGroupedByListName = propertyNames.Where(n => partOfAListRegex.IsMatch(n))
                    .GroupBy(n => partOfAListRegex.Match(n).Groups["ListName"].Value, n => n);

                foreach (IGrouping<string, string> group in propertyNamesGroupedByListName)
                {
                    List<string> sourcePropertyNames = group.ToList();
                    List<string> newPropertyValue = new List<string>();
                    string newPropertyName = group.Key;

                    foreach (var sourcePropertyName in sourcePropertyNames)
                    {
                        newPropertyValue.Add(item.Property(sourcePropertyName).Value.Value<string>());
                    }

                    item.Add(newPropertyName, JToken.FromObject(newPropertyValue));
                }

                return item.ToObject(objectType, JsonSerializer.CreateDefault());
            }

            throw new Exception();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }
}
