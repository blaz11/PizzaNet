using System.Collections.Generic;

namespace Pizza.Net.Screens.Tables.TableLegends
{
    class PizzasTableLegend
    {
        public string Name
        {
            get
            {
                return "Name";
            }
        }

        public string Price
        {
            get
            {
                return "Price";
            }
        }

        public ICollection<string> PizzaIngredients
        {
            get
            {
                var col = new List<string>();
                col.Add("Ingredients");
                return col;
            }
        }
    }
}