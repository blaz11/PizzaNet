using PizzaNetCore;
using System.Threading.Tasks;

namespace PizzaNetWebAPI.DatabaseAccess
{
    public class OrdersDB
    {
        public async Task<ClientOrdersModel> GetAllClientsOrders()
        {
            return null;
                foreach (var pizza in item.PizzaOrders)
                    foreach(var ingredient in pizza.Pizza.PizzaIngredients)
        }

        static public async Task AddOrder(OrderModel order)
        {
            var dbACcess = new PizzaNetDbAccess();
        }
    }
}