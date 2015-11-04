using Pizza.Net.Screens.Entities;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<PizzaEntityViewModel> Pizzas { get; set; }
        PizzaEntityViewModel SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {
        private ObservableCollection<PizzaEntityViewModel> _pizzas = new ObservableCollection<PizzaEntityViewModel>();
        public ObservableCollection<PizzaEntityViewModel> Pizzas
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

        private PizzaEntityViewModel _selectedPizza;
        public PizzaEntityViewModel SelectedPizza
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