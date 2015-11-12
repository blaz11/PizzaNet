using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

namespace Pizza.Net.Screens.Pages
{
    class PizzasPageViewModel : BaseTableInteractionViewModel, IPizzasPageViewModel
    {
        public PizzasPageViewModel(IPizzasTableViewModel _pizzasTableViewModel)
        {
            PizzasTableViewModel = _pizzasTableViewModel;
            SelectedIngredientsViewModel = new IngredientsTableViewModel();
            IngredientsToSelectViewModel = new IngredientsTableViewModel();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var ing = pne.Ingredients.Where(p => true);
                foreach (var v in ing)
                    IngredientsToSelectViewModel.Ingredients.Add(v);
            }
            Search();
        }

        public string PageName
        {
            get
            {
                return "Pizzas";
            }
        }

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

        private decimal _price;
        public decimal Price
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

        public IPizzasTableViewModel PizzasTableViewModel { get; private set; }
        public IIngredientsTableViewModel SelectedIngredientsViewModel { get; private set; }
        public IIngredientsTableViewModel IngredientsToSelectViewModel { get; private set; }

        private ICommand _addToSelectedCommand;
        public ICommand AddToSelectedCommand
        {
            get
            {
                if (_addToSelectedCommand == null)
                {
                    _addToSelectedCommand = new RelayCommand(
                        param => AddToSelected());
                }
                return _addToSelectedCommand;
            }
        }

        private ICommand _removeFromSelectedCommand;
        public ICommand RemoveFromSelectedCommand
        {
            get
            {
                if (_removeFromSelectedCommand == null)
                {
                    _removeFromSelectedCommand = new RelayCommand(
                        param => RemoveFromSelected());
                }
                return _removeFromSelectedCommand;
            }
        }

        private void AddToSelected()
        {
            var item = IngredientsToSelectViewModel.SelectedIngredient;
            if (item == null)
                return;
            IngredientsToSelectViewModel.Ingredients.Remove(item);
            SelectedIngredientsViewModel.Ingredients.Add(item);
        }

        private void RemoveFromSelected()
        {
            var item = SelectedIngredientsViewModel.SelectedIngredient;
            if (item == null)
                return;
            IngredientsToSelectViewModel.Ingredients.Add(item);
            SelectedIngredientsViewModel.Ingredients.Remove(item);
        }

        public override void Search()
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {

                var a = pne.Pizzas.Where(p =>
                (p.Name == Name || Name == "" || Name == null) &&
                (Price == 0 || p.Price == Price)
                );
                List<Domain.Pizza> lp = new List<Domain.Pizza>();
                foreach (var v in a)
                {
                    var b = pne.PizzaIngredients.Where(x => x.IDPizza == v.IDPizza).Select(y => y.IDIngredient).ToList();
                    foreach (var v1 in SelectedIngredientsViewModel.Ingredients)
                    {
                        if (!b.Contains(v1.IDIngredient))
                            lp.Add(v);
                    }

                }
                PizzasTableViewModel.Pizzas.Clear();
                foreach (var v in a)
                    if (!lp.Contains(v))
                        PizzasTableViewModel.Pizzas.Add(new PizzaViewModel(v));

            }
        }

        public override void Clear()
        {
            Name = "";
            Price = 0;
            foreach (var v in SelectedIngredientsViewModel.Ingredients)
            {
                IngredientsToSelectViewModel.Ingredients.Add(v);

            }
            SelectedIngredientsViewModel.Ingredients.Clear();
            Search();
        }

        private int _editedPizzaId;

        public override void Add()
        {
            if (SearchMode)
            {
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    Domain.Pizza p = new Domain.Pizza();
                    p.Name = Name;
                    p.Price = (decimal)Price;
                    pne.Pizzas.Add(p);
                    pne.SaveChanges();
                    foreach (var v in SelectedIngredientsViewModel.Ingredients)
                    {
                        pne.PizzaIngredients.Add(new PizzaIngredient
                        {
                            Pizza = pne.Pizzas.Find(p.IDPizza),
                            Ingredient = pne.Ingredients.Find(v.IDIngredient)
                        });
                    }
                    pne.SaveChanges();
                }
            }
            else
            {
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    var original = pne.Pizzas.Find(_editedPizzaId);
                    if (original != null)
                    {
                        original.Name = Name;
                        original.Price = (decimal)Price;
                        List<PizzaIngredient> p = new List<PizzaIngredient>();
                        foreach (var v in original.PizzaIngredients)
                        {
                            p.Add(v);

                        }
                        pne.PizzaIngredients.RemoveRange(p);
                        foreach (var v in SelectedIngredientsViewModel.Ingredients)
                        {
                            pne.PizzaIngredients.Add(new PizzaIngredient
                            {
                                Pizza = pne.Pizzas.Find(_editedPizzaId),
                                Ingredient = pne.Ingredients.Find(v.IDIngredient)
                            });
                        }
                        pne.SaveChanges();
                    }
                    SearchMode = true;
                }
                SearchMode = true;
            }
            Clear();
        }

        public override void Edit()
        {
            if (SearchMode)
            {
                if (PizzasTableViewModel.SelectedPizza != null)
                {
                    var pizza = PizzasTableViewModel.SelectedPizza;
                    if (pizza == null)
                        return;
                    Clear();
                    SearchMode = false;
                    _editedPizzaId = pizza.Pizza.IDPizza;
                    Name = pizza.Name;
                    Price = (decimal)pizza.Price;
                    foreach (var ingredient in pizza.Pizza.PizzaIngredients)
                    {
                        SelectedIngredientsViewModel.Ingredients.Add(ingredient.Ingredient);
                        IngredientsToSelectViewModel.Ingredients.Remove(ingredient.Ingredient);
                    }
                }
            }
            else
            {
                SearchMode = true;
            }
        }
    }
}
