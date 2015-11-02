using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.DesignTimeData
{
    class PizzasTable
    {
        public PizzasTable()
        {
            Pizzas = new ObservableCollection<PizzaEntity>();
            for (int i = 0; i < 15; i++)
            {
                Pizzas.Add(new PizzaEntity());
            }
        }

        public ObservableCollection<PizzaEntity> Pizzas { get; set; }
    }
}