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
        private IIngredientsTableViewModel SelectedIngredientsViewModel { get; }
        private IIngredientsTableViewModel IngredientsToSelectViewModel { get; }

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
            _selectedIngredients.Add(item);
            IngredientsToSelectViewModel.Ingredients.Remove(item);
        }

        private void RemoveFromSelected()
        {
            var item = SelectedIngredientsViewModel.SelectedIngredient;
            _selectedIngredients.Remove(item);
            IngredientsToSelectViewModel.Ingredients.Add(item);
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
