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
        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            ClientModel client = new ClientModel();
            return Ok();
        }
    }
}
