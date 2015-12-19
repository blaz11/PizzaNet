using PizzaNetCore;
using System.Collections.Generic;

namespace Pizza.Net.Screens.DesignTimeData
{
    class PizzaItem
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

        public ICollection<IngeredientModel> Ingredients
        {
            get
            {
                var col = new List<IngeredientModel>();
                var ing = new IngeredientModel();
                ing.Name = "Salami";
                for (int i = 0; i < 3; ++i)
                    col.Add(ing);
                return col;
            }
        }
    }
}