using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Instructions { get; set; }
        public List<string> Ingredients { get; set; }
        public string ImageURL { get; set; }
    }
}
