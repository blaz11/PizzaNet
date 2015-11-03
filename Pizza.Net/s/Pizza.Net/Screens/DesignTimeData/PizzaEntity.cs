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

        public ICollection<Ingredient> Ingredients
        {
            get
            {
                var col = new List<Ingredient>();
                var ing = new Ingredient()
                {
                    Name = "Salami",
                };
                for (int i = 0; i < 3; ++i)
                    col.Add(ing);
                return col;
            }
        }
    }
}