using System.Collections.Generic;

namespace PizzaNetCore
{
    public class PizzaModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IEnumerable<IngeredientModel> Ingredients { get; set; } 
    }

    public class IngeredientModel
    {
        public string Name { get; set; }
    }
}