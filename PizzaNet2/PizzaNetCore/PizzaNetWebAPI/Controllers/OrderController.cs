using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaNetCore;

namespace PizzaNetWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IHttpActionResult Get()
        {
            List<OrderModel> ord = null;

            if (ord == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // GET: api/Order/5
        public IHttpActionResult Get(int id)
        {
            OrderModel ord = null;

            if (ord == null)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Order
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Order/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Order/5
        public void Delete(int id)
        {
        }
    }
}
