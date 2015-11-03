using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<Domain.Pizza> Pizzas { get; set; }
        Domain.Pizza SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {
        private ObservableCollection<Pizza.Net.Domain.Pizza> _pizzas = new ObservableCollection<Domain.Pizza>();
        public ObservableCollection<Pizza.Net.Domain.Pizza> Pizzas
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

        private Domain.Pizza _selectedPizza;
        public Domain.Pizza SelectedPizza
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