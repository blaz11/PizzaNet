using Pizza.Net.Domain.DatabaseAccess;
using System.Threading.Tasks;
using System.Linq;
using System;
using PizzaNetCore;
using System.Collections.Generic;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class OrdersDB
    {
        static public async Task<ClientOrdersModel> GetAllClientsOrders(string username)
        {
            var clientID = Convert.ToInt32(await ClientsDB.GetClientID(username));
            var dbACcess = new PizzaNetDbAccess();
            var f = new Func<DbOperationContext, IQueryable<Pizza.Net.Domain.Order>>((db) =>
            {
                return db.Entities.Orders.Where(p => p.Client.IDClient == clientID);
            });
            var ordersEntities = await dbACcess.ExecuteInTransactionAsync(f);
            var result = new ClientOrdersModel();
            var ordersList = new List<OrderModel>();
            foreach (var item in ordersEntities)
            {
                var order = new OrderModel();
                order.FinishOrderDate = item.FinishOrderDate;
                order.StartOrderDate = item.StartOrderDate;
                var pizzasList = new List<PizzaInOrderModel>();
                foreach(var pizza in item.PizzaOrders)
                {
                    var pizzaModel = new PizzaInOrderModel();
                    pizzaModel.PizzaModel = new PizzaModel();
                    pizzaModel.SizeModel = new SizeModel();
                    pizzaModel.SizeModel.Name = pizza.Size.Name;
                    pizzaModel.SizeModel.PriceMultiplier = pizza.Size.BasePriceMultiplier;
                    pizzaModel.SizeModel.Radius = pizza.Size.RadiusInCm;
                    pizzaModel.PizzaModel.Name = pizza.Pizza.Name;
                    var ingList = new List<IngeredientModel>();
                    foreach(var ingredient in pizza.Pizza.PizzaIngredients)
                    {
                        var ing = new IngeredientModel();
                        ing.Name = ingredient.Ingredient.Name;
                        ingList.Add(ing);
                    }
                    pizzaModel.PizzaModel.Ingredients = ingList;
                    pizzasList.Add(pizzaModel);
                }
                order.Pizzas = pizzasList;
                ordersList.Add(order);
            }
            result.Orders = ordersList;
            return result;
        }
    }
}