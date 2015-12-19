using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class PizzasTable
    {
        public PizzasTable()
        {
            Pizzas = new ObservableCollection<PizzaItem>();
            for (int i = 0; i < 15; i++)
            {
                Pizzas.Add(new PizzaItem());
            }
        }

        public ObservableCollection<PizzaItem> Pizzas { get; set; }
    }
}