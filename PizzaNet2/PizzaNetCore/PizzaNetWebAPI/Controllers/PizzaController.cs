using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaNetCore;

namespace PizzaNetWebAPI.Controllers
{
    public class PizzaController : ApiController
    {
        // GET: api/Pizza
        public IHttpActionResult Get()
        {
            List<PizzaModel> ord = null;

            if (ord == null)
            {
                return NotFound();
            }
            return Ok();
        }

     
    }
}
