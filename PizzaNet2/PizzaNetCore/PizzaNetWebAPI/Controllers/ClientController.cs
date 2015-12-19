using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http;
using PizzaNetCore;

namespace PizzaNetWebAPI.Controllers
{
    public class ClientController : ApiController
    {
        // GET: api/Client
        public IHttpActionResult Get()
        {
            ClientModel client = null;

            if (client == null)
            {
                return NotFound();
            }
            return Ok();
        }
        // PUT: api/Client/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            ClientModel client = new ClientModel();
            return Ok();
        }
    }
}
