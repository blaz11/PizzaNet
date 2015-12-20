using PizzaNetCore;
using System.Threading.Tasks;

namespace Pizza.Net.RestAPIAccess
{
    class OrderAccess : TokenAuthenticatedWebServiceAccess
    {
        public OrderAccess(LoggedUser user) : base(user)
        {
        }


        public async Task<string> Post(OrderModel orderModel)
        {
            var url = "Order";
            return await this.Post<OrderModel, string>(url, orderModel);
        }

        public async Task<ClientOrdersModel> Get()
        {
            var url = "Order";
            return await this.Get<ClientOrdersModel>(url);
        }
    }
}