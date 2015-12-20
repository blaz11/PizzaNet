using System.Web.Http;
using PizzaNetCore;
using PizzaNetWebAPI.DatabaseAccess;

namespace PizzaNetWebAPI.Controllers
{
    [Authorize]
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IHttpActionResult Get()
        {
            ClientModel client = ClientsDB.GetClientModel(User.Identity.Name);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // POST: api/Client
        public IHttpActionResult Post(ClientModel client)
        {
            ClientsDB.AlterClient(client, User.Identity.Name);
            return Ok();
        }
    }
}
