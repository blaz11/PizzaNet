using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pizza.Net.Domain;
using System.ComponentModel;
using Pizza.Net.Screens.Tables;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Pizza.Net.Screens.Pages
{
    public interface IPizzasPageModel
    {
        ObservableCollection<Ingredient> getIngridients();
        void Add(ObservableCollection<Ingredient> ingr);
        void Edit(ObservableCollection<Ingredient> ingr, int _editedPizzaId);
        ObservableCollection<PizzaViewModel> Search(ObservableCollection<Ingredient> ingr);
    }
    public class PizzasPageModel : IPizzasPageModel, IDataErrorInfo
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string propertyName]
        {
            get
            {
                string validationResult = null;
                switch (propertyName)
                {
                    case ("Name"):
                        validationResult = ValidateName();
                        break;
                    case "Price":
                        validationResult = ValidatePrice();
                        break;
                    default:
                        throw new ApplicationException("Unknown Property being validated on Product.");
                }
                return validationResult;
            }
        }

        private string ValidateName()
        {
            if (String.IsNullOrEmpty(this.Name))
                return "Name needs to be entered.";
            else if (this.Name.Length < 2)
                return "Name should have more than 1 letters.";
            else
                return String.Empty;
        }

        private string ValidatePrice()
        {
            if(Price<1)
                return "Price must be a number greater than 0.";
            return String.Empty;
        }
        public ObservableCollection<Ingredient> getIngridients()
        {
            ObservableCollection<Ingredient> ing = new ObservableCollection<Ingredient>();
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                ing.Clear();
                var a = pne.Ingredients.Where(p => true);
                foreach (var v in a)
                    ing.Add(v);
            }

            return ing;
        }
        public void Add(ObservableCollection<Ingredient> ingr)
        {
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                Domain.Pizza p = new Domain.Pizza();
                p.Name = Name;
                p.Price = (decimal)Price;
                pne.Pizzas.Add(p);
                pne.SaveChanges();
                foreach (var v in ingr)
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
        public void Edit(ObservableCollection<Ingredient> ingr, int _editedPizzaId)
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
                    foreach (var v in ingr)
                    {
                        pne.PizzaIngredients.Add(new PizzaIngredient
                        {
                            Pizza = pne.Pizzas.Find(_editedPizzaId),
                            Ingredient = pne.Ingredients.Find(v.IDIngredient)
                        });
                    }
                    pne.SaveChanges();
                }
            }
        }
        public ObservableCollection<PizzaViewModel> Search(ObservableCollection<Ingredient> ingr)
        {
            ObservableCollection<PizzaViewModel> piz = new ObservableCollection<PizzaViewModel>();
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
                    foreach (var v1 in ingr)
                    {
                        if (!b.Contains(v1.IDIngredient))
                            lp.Add(v);
                    }

                }
                piz.Clear();
                foreach (var v in a)
                    if (!lp.Contains(v))
                        piz.Add(new PizzaViewModel(v));

            }
            return piz;
        }
    }
}
