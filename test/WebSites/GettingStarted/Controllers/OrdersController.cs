using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GettingStarted.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(int))]
        [ProducesResponseType(400, Type = typeof(Dictionary<string, string>))]
        [ProducesResponseType(500)]
        public int CreateOrder([FromBody]Order order)
        {
            return 123;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204, Type = typeof(void))]
        [ProducesDefaultResponseType(typeof(Dictionary<string, string>))]
        public void DeleteOrder(int id)
        {
        }
    }

    public class Order
    {
        public int Id { get; internal set; }

        public IEnumerable<OrderItem> Items { get; set; }
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
