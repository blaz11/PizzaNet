using Pizza.Net.Domain;
using Pizza.Net.Screens.Tables;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;


namespace Pizza.Net.Screens.Pages
{
    class PizzasPageViewModel : BaseTableInteractionViewModel, IPizzasPageViewModel
    {
        public PizzasPageViewModel(IPizzasTableViewModel _pizzasTableViewModel)
        {
            PizzasTableViewModel = _pizzasTableViewModel;
            //Janek wszystkie ingredients z bazy danych dodaj do IngredientsToSelectViewModel i przy clearze zresetuj je.
            SelectedIngredientsViewModel = new IngredientsTableViewModel();
            IngredientsToSelectViewModel = new IngredientsTableViewModel();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var ing = pne.Ingredients.Where(p => true);
                foreach (var v in ing)
                    IngredientsToSelectViewModel.Ingredients.Add(v);
            }
            Search();
     /*       Ingredient i1 = new Ingredient();
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
            PizzasTableViewModel.Pizzas.Add(new PizzaViewModel(p));*/
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
            //Janek TODO szukanie po cenie i skladnikach
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
           
                var a = pne.Pizzas.Where(p =>
                (p.Name == Name || Name == "" || Name == null) &&
                (Price == 0 || p.Price == Price)
                );
                List<Domain.Pizza> lp = new List<Domain.Pizza>();
                foreach(var v in a)
                {
                    var b = pne.PizzaIngredients.Where(x => x.IDPizza == v.IDPizza).Select(y => y.IDIngredient).ToList();
                    foreach(var v1 in SelectedIngredientsViewModel.Ingredients)
                    {
                        if (!b.Contains(v1.IDIngredient))
                            lp.Add(v);
                    }

                }
                PizzasTableViewModel.Pizzas.Clear();
                foreach (var v in a)
                    if(!lp.Contains(v))
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
            //Janek
        }

        public override void Add()
        {


            if (SearchMode)
            {
                //Tutaj dodajemy nowy
                //Janek
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    Domain.Pizza p = new Domain.Pizza();
                    p.Name = Name;
                    p.Price = (decimal)Price;
                    pne.Pizzas.Add(p);
                    pne.SaveChanges();
                    System.Console.WriteLine(p.IDPizza);
                    foreach (var v in SelectedIngredientsViewModel.Ingredients)
                    {
                        //         System.Console.WriteLine(v);
                        pne.PizzaIngredients.Add(new PizzaIngredient
                        {
                            Pizza = pne.Pizzas.Find(p.IDPizza),
                            Ingredient = pne.Ingredients.Find(v.IDIngredient)
                        });
                    }
                    pne.SaveChanges();
                    //         System.Console.WriteLine();

                }
            }
            else
            {
                //Tutaj edytujemy
                using (PizzaNetEntities pne = new PizzaNetEntities())
                {
                    int id = PizzasTableViewModel.SelectedPizza.Pizza.IDPizza;
                    var original = pne.Pizzas.Find(id);

                    if (original != null)
                    {
                        original.Name = Name;
                        original.Price = (decimal)Price;
                        List<PizzaIngredient> p = new List<PizzaIngredient>();
                        foreach(var v in original.PizzaIngredients)
                        {
                            p.Add(v);
                           
                        }
                        pne.PizzaIngredients.RemoveRange(p);
                        foreach (var v in SelectedIngredientsViewModel.Ingredients)
                        {
                            //         System.Console.WriteLine(v);
                            pne.PizzaIngredients.Add(new PizzaIngredient
                            {
                                Pizza = pne.Pizzas.Find(id),
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
