using System.Collections.Generic;

namespace PizzaNetCore
{
    public class MenuModel
    {
        public IEnumerable<PizzaModel> Pizzas { get; set; }
    }
}