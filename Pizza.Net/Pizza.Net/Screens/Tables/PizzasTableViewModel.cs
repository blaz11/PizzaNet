using System.Collections.ObjectModel;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Data.Entity;

namespace Pizza.Net.Screens.Tables
{
    interface IPizzasTableViewModel
    {
        ObservableCollection<PizzaViewModel> Pizzas { get; set; }
        PizzaViewModel SelectedPizza { get; set; }
    }

    class PizzasTableViewModel : ObservableObject, IPizzasTableViewModel
    {
        public PizzasTableViewModel()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Pizzas.Where(p =>true);
                //     System.Console.WriteLine(a);
                List<Domain.Pizza> pl = new List<Domain.Pizza>();
                Pizzas.Clear();
                foreach (var v in a)
                    Pizzas.Add(new PizzaViewModel(v));
            }
        }
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