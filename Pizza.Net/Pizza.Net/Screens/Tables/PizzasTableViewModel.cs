using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        PizzaViewModel SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {
        private ObservableCollection<PizzaViewModel> _pizzas = new ObservableCollection<PizzaViewModel>();
        public ObservableCollection<PizzaViewModel> Pizzas
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

        private PizzaViewModel _selectedPizza;
        public PizzaViewModel SelectedPizza
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