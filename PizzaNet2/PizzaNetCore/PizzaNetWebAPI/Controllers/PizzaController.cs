using System.Web.Http;
using PizzaNetWebAPI.DatabaseAccess;

namespace PizzaNetWebAPI.Controllers
{
    public class PizzaController : ApiController
    {
        // GET: api/Pizza
        public IHttpActionResult Get()
        {
            var model = PizzasDB.GetMenu();
            return Ok(model);
        }
    }
}