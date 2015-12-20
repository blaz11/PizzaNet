using System.Web.Http;
using PizzaNetCore;
using PizzaNetWebAPI.DatabaseAccess;

namespace PizzaNetWebAPI.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IHttpActionResult Get()
        {
            var model = OrdersDB.GetAllClientsOrders(User.Identity.Name);
            return Ok(model);
        }

        // POST: api/Order
        public IHttpActionResult Post([FromBody]OrderModel value)
        {
            OrdersDB.AddOrder(value, User.Identity.Name);
            return Ok();
        }
    }
}
