using CocktailDb.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CocktailDb
{
    public class ListJsonConverter : JsonConverter
    {
        private Regex partOfAListRegex = new Regex(@"^(?<ListName>.*)[0-9]+$");

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Cocktail);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.PropertyName)
                return serializer.Deserialize(reader, objectType);

            var regexMatch = partOfAListRegex.Match(reader.Value as string);

            if (!regexMatch.Success)
                return serializer.Deserialize(reader, objectType);

            //TODO: figure out how to do the rest!?
            return serializer.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanWrite => false;
    }
}
