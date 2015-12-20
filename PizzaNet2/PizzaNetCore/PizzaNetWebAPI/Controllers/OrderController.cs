using System.Web.Http;
using PizzaNetCore;
using PizzaNetWebAPI.DatabaseAccess;
using PizzaNetWebAPI.Email;

namespace PizzaNetWebAPI.Controllers
{
    [Authorize]
    public class OrderController : ApiController
    {
        private EmailSender _emailSender = new EmailSender();

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
            ClientModel client = ClientsDB.GetClientModel(User.Identity.Name);
            var creator = new OrderConfirmationEmailCreator(value, client);
            _emailSender.SendEmail(User.Identity.Name, creator);
            return Ok();
        }
    }
}
