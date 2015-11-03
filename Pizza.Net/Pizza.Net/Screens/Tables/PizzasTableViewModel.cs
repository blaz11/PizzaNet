using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<Domain.Pizza> Pizza { get; set; }
        Domain.Pizza SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {
        private ObservableCollection<Pizza.Net.Domain.Pizza> _pizza = new ObservableCollection<Domain.Pizza>();
        public ObservableCollection<Pizza.Net.Domain.Pizza> Pizza
        {
            get
            {
                return _pizza;
            }
            set
            {
                if (value != _pizza)
                {
                    _pizza = value;
                    OnPropertyChanged();
                }
            }
        }

        private Pizza.Net.Domain.Pizza _selectedPizza;
        public Pizza.Net.Domain.Pizza SelectedPizza
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