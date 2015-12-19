using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PizzaNetCore;

namespace PizzaNetWebAPI.Controllers
{
    [Authorize]
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


        // POST: api/Order
        public IHttpActionResult Post(IEnumerable<OrderModel> value)
        {
            OrderModel ord = new OrderModel();

            return Ok();

        }

    }
}
