using System.Collections.Generic;

namespace PizzaNetCore
{
    class MenuModel
    {
        public IEnumerable<PizzaModel> Pizzas { get; set; }
    }
}