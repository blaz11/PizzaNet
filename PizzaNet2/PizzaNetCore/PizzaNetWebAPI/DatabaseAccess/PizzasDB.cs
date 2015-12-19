using System.Threading.Tasks;
using PizzaNetCore;
using Pizza.Net.Domain.DatabaseAccess;
using System.Collections.Generic;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class PizzasDB
    {
        static public async Task<MenuModel> GetMenu()
        {
            var menuModel = new MenuModel();
            var pizzaList = new List<PizzaModel>();
            var dbAccess = new PizzaNetDbAccess();
            await dbAccess.ExecuteInTransactionAsync((db) =>
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
                    pizzaList.Add(model);
                }
            });
            menuModel.Pizzas = pizzaList;
            return menuModel;
        }
    }
}