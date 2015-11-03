using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.Generic;
using System.Windows.Input;

namespace Pizza.Net.Screens.Pages
{
    class PizzasPageViewModel : BasePageViewModel, IPizzasPageViewModel
    {
        public PizzasPageViewModel(IPizzasTableViewModel _pizzasTableViewModel)
        {
            PizzasTableViewModel = _pizzasTableViewModel;
            //Janek wszystkie ingredients z bazy danych dodaj do IngredientsToSelectViewModel i przy clearze zresetuj je.
            SelectedIngredientsViewModel = new IngredientsTableViewModel();
            IngredientsToSelectViewModel = new IngredientsTableViewModel();
            Ingredient i1 = new Ingredient();
            i1.Name = "Cheese";
            SelectedIngredientsViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Ham";
            SelectedIngredientsViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Pineapple";
            IngredientsToSelectViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Salami";
            IngredientsToSelectViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Grilled chicken";
            IngredientsToSelectViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Tuna";
            IngredientsToSelectViewModel.Ingredients.Add(i1);
            i1 = new Ingredient();
            i1.Name = "Tomato";
            IngredientsToSelectViewModel.Ingredients.Add(i1);
            Pizza.Net.Domain.Pizza p = new Domain.Pizza();
            p.Name = "Cheese pizza";
            p.Price = 23;
            i1 = new Ingredient();
            i1.Name = "Cheese";
            var s = new PizzaIngredient();
            s.Ingredient = i1;
            p.PizzaIngredients.Add(s);
            i1 = new Ingredient();
            i1.Name = "Salami";
            s = new PizzaIngredient();
            s.Ingredient = i1;
            p.PizzaIngredients.Add(s);
            PizzasTableViewModel.Pizzas.Add(p);
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

        private HashSet<Ingredient> _selectedIngredients = new HashSet<Ingredient>();
        public IPizzasTableViewModel PizzasTableViewModel { get; }
        public IIngredientsTableViewModel SelectedIngredientsViewModel { get; }
        public IIngredientsTableViewModel IngredientsToSelectViewModel { get; }

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
            _selectedIngredients.Add(item);
            IngredientsToSelectViewModel.Ingredients.Remove(item);
            SelectedIngredientsViewModel.Ingredients.Add(item);
        }

        private void RemoveFromSelected()
        {
            var item = SelectedIngredientsViewModel.SelectedIngredient;
            if (item == null)
                return;
            _selectedIngredients.Remove(item);
            IngredientsToSelectViewModel.Ingredients.Add(item);
            SelectedIngredientsViewModel.Ingredients.Remove(item);
        }

        public override void Search()
        {
            //Janek
        }

        public override void Clear()
        {
            Name = null;
            //Janek
        }

        public override void Add()
        {
            //Janek
            if (SearchMode)
            {
                //Tutaj dodajemy nowy
            }
            else
            {
                //Tutaj edytujemy
                SearchMode = true;
            }
        }

        public override void Edit()
        {
            //Janek
            if (SearchMode)
            {
                if(PizzasTableViewModel.SelectedPizza != null)
                {
                    SearchMode = false;
                    var pizza =  PizzasTableViewModel.SelectedPizza;
                    Name = pizza.Name;
                }
            }
            else
            {
                SearchMode = true;
            }
        }
    }
}
