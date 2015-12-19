using System.Collections.ObjectModel;
using PizzaNetCore;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<PizzaModel> Pizzas { get; set; }
        PizzaModel SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {

        private ObservableCollection<PizzaModel> _pizzas = new ObservableCollection<PizzaModel>();
        public ObservableCollection<PizzaModel> Pizzas
        {
            get
            {
                return _pizzas;
            }
            set
            {
                if (value != _pizzas)
                {
                    _pizzas = value;
                    OnPropertyChanged();
                }
            }
        }

        private PizzaModel _selectedPizza;
        public PizzaModel SelectedPizza
        {
            get
            {
                return _selectedPizza;
            }
            set
            {
                if (value != _selectedPizza)
                {
                    _selectedPizza = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}