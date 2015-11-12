using Pizza.Net.Domain;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Entities
{
    class PizzaEntityViewModel : ObservableObject
    {
        public PizzaEntityViewModel(Domain.Pizza pizza)
        {
            Ingredients = ConvertFromPizzaOrderCollectionToStringCollection(pizza.PizzaIngredients);
            Name = pizza.Name;
            Price = (double)pizza.Price;
            Pizza = pizza;
        }

        private ObservableCollection<string> ConvertFromPizzaOrderCollectionToStringCollection(ICollection<PizzaIngredient> pizzaIngredients)
        {
            var converted = new ObservableCollection<string>();
            foreach (var item in pizzaIngredients)
            {
                string v = item.Ingredient.Name;
                converted.Add(v);
            }
            return converted;
        }

        public Domain.Pizza Pizza { get; }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private double _price;
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _ingredients;
        public ObservableCollection<string> Ingredients
        {
            get
            {
                return _ingredients;
            }
            set
            {
                if (value != _ingredients)
                {
                    _ingredients = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}