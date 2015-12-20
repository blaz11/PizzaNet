using PizzaNetCore;
using Pizza.Net.Domain.DatabaseAccess;
using System.Collections.Generic;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class PizzasDB
    {
        static public MenuModel GetMenu()
        {
            var menuModel = new MenuModel();
            var pizzaList = new List<PizzaModel>();
            var sizeList = new List<SizeModel>();
            var dbAccess = new PizzaNetDbAccess();
            dbAccess.ExecuteInTransaction((db) =>
            {
                foreach(var item in db.Entities.Pizzas)
                {
                    var model = new PizzaModel();
                    model.Name = item.Name;
                    model.Price = (double)item.Price;
                    var ingList = new List<IngeredientModel>();
                    foreach(var ing in item.PizzaIngredients)
                    {
                        var ingModel = new IngeredientModel();
                        ingModel.Name = ing.Ingredient.Name;
                        ingList.Add(ingModel);
                    }
                    model.Ingredients = ingList;
                    model.ID = item.IDPizza;
                    pizzaList.Add(model);
                }
                foreach (var item in db.Entities.Sizes)
                {
                    var model = new SizeModel();
                    model.ID = item.IDSize;
                    model.Name = item.Name;
                    model.PriceMultiplier = item.BasePriceMultiplier;
                    model.Radius = item.RadiusInCm;
                    sizeList.Add(model);
                }
            });
            menuModel.Pizzas = pizzaList;
            menuModel.Sizes = sizeList;
            return menuModel;
        }
    }
}