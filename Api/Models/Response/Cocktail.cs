using System.Collections.Generic;

namespace api.Models.Response
{
    public class Cocktail
    {
        public Cocktail(Domain.Entities.Cocktail entity)
        {
            Id              = entity.Id;
            Name            = entity.Name;
            Instructions    = entity.Instructions;
            Ingredients     = entity.Ingredients;
            ImageURL        = entity.ImageURL;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageURL { get; set; }
    }
}