using Pizza.Net.Domain.DatabaseAccess;
using System.Linq;
using System;
using PizzaNetCore;
using System.Collections.Generic;

namespace PizzaNetWebAPI.DatabaseAccess
{
    static public class OrdersDB
    {
        static public ClientOrdersModel GetAllClientsOrders(string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            var result = new ClientOrdersModel();
            var ordersList = new List<OrderModel>();
            dbACcess.ExecuteInTransaction((db) =>
            {
                var cu = db.Entities.ClientsAspNetUsers.Where(p => p.AspNetUser.UserName == username);
                Pizza.Net.Domain.Client client = cu.FirstOrDefault().Client;
                var ordersEntities = db.Entities.Orders.Where(p => p.Client.IDClient == client.IDClient);
                foreach (var item in ordersEntities)
                {
                    var order = new OrderModel();
                    order.FinishOrderDate = item.FinishOrderDate;
                    order.StartOrderDate = item.StartOrderDate;
                    var pizzasList = new List<PizzaInOrderModel>();
                    foreach (var pizza in item.PizzaOrders)
                    {
                        var pizzaModel = new PizzaInOrderModel();
                        pizzaModel.PizzaModel = new PizzaModel();
                        pizzaModel.SizeModel = new SizeModel();
                        pizzaModel.SizeModel.Name = pizza.Size.Name;
                        pizzaModel.SizeModel.PriceMultiplier = pizza.Size.BasePriceMultiplier;
                        pizzaModel.SizeModel.Radius = pizza.Size.RadiusInCm;
                        pizzaModel.PizzaModel.Name = pizza.Pizza.Name;
                        pizzaModel.PizzaModel.Price = (double)pizza.Pizza.Price;
                        var ingList = new List<IngeredientModel>();
                        foreach (var ingredient in pizza.Pizza.PizzaIngredients)
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
            });
            return result;
        }

        static public void AddOrder(OrderModel order, string username)
        {
            var dbACcess = new PizzaNetDbAccess();
            dbACcess.ExecuteInTransaction((db) =>
            {
                var orderEntity = new Pizza.Net.Domain.Order();
                orderEntity.FinishOrderDate = new DateTime(1800, 1, 1);
                orderEntity.StartOrderDate = order.StartOrderDate;
                var pizzaOrderEntities = new List<Pizza.Net.Domain.PizzaOrder>();
                foreach (var pizza in order.Pizzas)
                {
                    var pizzaOrderEntity = new Pizza.Net.Domain.PizzaOrder();
                    pizzaOrderEntity.Size = db.Entities.Sizes.Where(p => p.IDSize == pizza.SizeModel.ID).First();
                    pizzaOrderEntity.Pizza = db.Entities.Pizzas.Where(p => p.IDPizza == pizza.PizzaModel.ID).First();
                    pizzaOrderEntities.Add(pizzaOrderEntity);
                }
                orderEntity.Client = db.Entities.ClientsAspNetUsers.Where(p => p.AspNetUser.UserName == username).First().Client;
                orderEntity.PizzaOrders = pizzaOrderEntities;
                db.Entities.Orders.Add(orderEntity);
            });
        }
    }
}