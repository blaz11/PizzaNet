using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pizza.Net.Domain;
using Pizza.Net.Screens.Pages;
using System.Data.Entity;
using System.Linq;

namespace Pizza.Net.Tests.Tests
{
  /*  [TestClass]
    public class PizzasPageModelShould
    {
        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<PizzaNetEntities>());
            Database.SetInitializer(new CreateDatabaseIfNotExists<PizzaNetEntities>());
        }

        [TestMethod]
        public void NotAddNewPizzaWithNotUniqueName()
        {
            var pizzaPageModel = new PizzasPageModel();
            pizzaPageModel.Name = "Unique1";
            pizzaPageModel.Price = 23;
            var ingredients = new System.Collections.ObjectModel.ObservableCollection<Domain.Ingredient>();
            pizzaPageModel.Add(ingredients);
            var result = pizzaPageModel.Add(ingredients);
            Assert.AreEqual(result, false);
        }

        [TestMethod]
        public void AddNewPizzaWithUniqueName()
        {
            var pizzaPageModel = new PizzasPageModel();
            pizzaPageModel.Name = "VeryUniqueName";
            pizzaPageModel.Price = 23;
            var ingredients = new System.Collections.ObjectModel.ObservableCollection<Domain.Ingredient>();
            pizzaPageModel.Add(ingredients);
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Pizzas.Where(p =>
                    (p.Name == pizzaPageModel.Name) &&
                    (p.Price == pizzaPageModel.Price)
                );
                var addedPizza = a.FirstOrDefault();
                Assert.AreNotEqual(addedPizza, null);
            }
        }

        [TestMethod]
        public void EditPizzaWithUniqeName()
        {
            var pizzaPageModel = new PizzasPageModel();
            pizzaPageModel.Name = "VeryUniqueName";
            pizzaPageModel.Price = 23;
            var ingredients = new System.Collections.ObjectModel.ObservableCollection<Domain.Ingredient>();
            pizzaPageModel.Add(ingredients);
            pizzaPageModel.Name = "NewVeryUniqueName";
            var result = pizzaPageModel.Edit(ingredients, 1);
            Assert.AreEqual(result, true);
            using (PizzaNetEntities pne = new PizzaNetEntities())
            {
                var a = pne.Pizzas.Where(p =>
                    (p.Name == pizzaPageModel.Name)
                );
                var addedPizza = a.FirstOrDefault();
                Assert.AreNotEqual(addedPizza, null);
            }
        }

        [TestMethod]
        public void NotEditPizzaWithNotUniqeName()
        {
            var pizzaPageModel = new PizzasPageModel();
            pizzaPageModel.Name = "NotVeryUniqueName";
            pizzaPageModel.Price = 23;
            var ingredients = new System.Collections.ObjectModel.ObservableCollection<Domain.Ingredient>();
            pizzaPageModel.Add(ingredients);
            pizzaPageModel.Name = "NotVeryUniqueName";
            var result = pizzaPageModel.Edit(ingredients, 1);
            Assert.AreEqual(result, false);
        }
    }*/
}