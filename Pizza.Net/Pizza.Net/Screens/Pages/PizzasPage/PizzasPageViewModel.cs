using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Pizza.Net.Screens.Pages
{
    class PizzasPageViewModel : BaseTableInteractionViewModel, IPizzasPageViewModel, IDataErrorInfo
    {
        private readonly PizzasPageModel _currentPizzasPageModel;
        private Dictionary<string, bool> validProperties;
        public PizzasPageViewModel(IPizzasTableViewModel _pizzasTableViewModel, PizzasPageModel newPizzasPageModel)
        {
            _currentPizzasPageModel = newPizzasPageModel;
            PizzasTableViewModel = _pizzasTableViewModel;
            SelectedIngredientsViewModel = new IngredientsTableViewModel();
            IngredientsToSelectViewModel = new IngredientsTableViewModel();
            this.validProperties = new Dictionary<string, bool>();
            this.validProperties.Add("Name", false);
            this.validProperties.Add("Price", false);
            foreach (var v in _currentPizzasPageModel.getIngridients())
                IngredientsToSelectViewModel.Ingredients.Add(v);
            Search();
        }
        private bool allPropertiesValid = false;
        public bool AllPropertiesValid
        {
            get { return allPropertiesValid; }
            set
            {
                if (allPropertiesValid != value)
                {
                    allPropertiesValid = value;
                    base.OnPropertyChanged("AllPropertiesValid");
                }
            }
        }
        public string PageName
        {
            get
            {
                return "Pizzas";
            }
        }

        public string Name
        {
            get
            {
                return _currentPizzasPageModel.Name;
            }
            set
            {
                if (value != _currentPizzasPageModel.Name)
                {
                    _currentPizzasPageModel.Name = value;
                    base.OnPropertyChanged();
                }
            }
        }

        public decimal Price
        {
            get
            {
                return _currentPizzasPageModel.Price;
            }
            set
            {
                if (value != _currentPizzasPageModel.Price)
                {
                    _currentPizzasPageModel.Price = value;
                    base.OnPropertyChanged();
                }
            }
        }

        #region IDataErrorInfo members

        public string Error
        {
            get { return (_currentPizzasPageModel as IDataErrorInfo).Error; }
        }

        public string this[string propertyName]
        {
            get
            {
                string error = (_currentPizzasPageModel as IDataErrorInfo)[propertyName];
                validProperties[propertyName] = String.IsNullOrEmpty(error) ? true : false;
                ValidateProperties();
                CommandManager.InvalidateRequerySuggested();
                return error;
            }
        }
        private void ValidateProperties()
        {
            foreach (bool isValid in validProperties.Values)
            {
                if (!isValid)
                {
                    this.AllPropertiesValid = false;
                    return;
                }
            }
            this.AllPropertiesValid = true;
        }
        #endregion
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
            bool contains = false;
            foreach (var v in SelectedIngredientsViewModel.Ingredients)
                if (v.IDIngredient == item.IDIngredient)
                    contains = true;
            
            if (!contains)
            {
                IngredientsToSelectViewModel.Ingredients.Remove(item);
                SelectedIngredientsViewModel.Ingredients.Add(item);
            }
        }

        private void RemoveFromSelected()
        {
            var item = SelectedIngredientsViewModel.SelectedIngredient;
            if (item == null)
                return;
            bool contains = false;
            foreach (var v in IngredientsToSelectViewModel.Ingredients)
                if (v.IDIngredient == item.IDIngredient)
                    contains = true;
            if (!contains) 
                IngredientsToSelectViewModel.Ingredients.Add(item);
            SelectedIngredientsViewModel.Ingredients.Remove(item);
            
        }

        public override void Search()
        {
            ObservableCollection<Ingredient> ingr = new ObservableCollection<Ingredient>();
            foreach (var v in SelectedIngredientsViewModel.Ingredients)
                ingr.Add(v);
            PizzasTableViewModel.Pizzas.Clear();
            foreach (var v in _currentPizzasPageModel.Search(ingr))
                PizzasTableViewModel.Pizzas.Add(v);
         /*   using (PizzaNetEntities pne = new PizzaNetEntities())
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

            }*/
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
                ObservableCollection<Ingredient> ingr = new ObservableCollection<Ingredient>();
                foreach (var v in SelectedIngredientsViewModel.Ingredients)
                    ingr.Add(v);
                _currentPizzasPageModel.Add(ingr);
             /*       using (PizzaNetEntities pne = new PizzaNetEntities())
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
                }*/
            }
            else
            {
                ObservableCollection<Ingredient> ingr = new ObservableCollection<Ingredient>();
                foreach (var v in SelectedIngredientsViewModel.Ingredients)
                    ingr.Add(v);
                _currentPizzasPageModel.Edit(ingr, _editedPizzaId);

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
