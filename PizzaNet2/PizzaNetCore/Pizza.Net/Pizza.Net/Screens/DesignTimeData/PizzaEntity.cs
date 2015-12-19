using Pizza.Net.Domain;
using System.Collections.Generic;

namespace Pizza.Net.Screens.DesignTimeData
{
    class PizzaEntity
    {
        public string Name
        {
            get
            {
                return "Hawajska";
            }
        }

        public string Price
        {
            get
            {
                return "54";
            }
        }

        public ICollection<PizzaIngredient> Ingredients
        {
            get
            {
                var col = new List<PizzaIngredient>();
                var ing = new PizzaIngredient();
                ing.Ingredient.Name = "Salami";
                for (int i = 0; i < 3; ++i)
                    col.Add(ing);
                return col;
            }
        }
    }
}