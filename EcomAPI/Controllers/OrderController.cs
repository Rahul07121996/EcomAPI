using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // Hardcoded list of orders
        private static readonly List<Order> Orders = new()
        {
            new Order { Id = 1, CustomerName = "Alice Johnson", Product = "Wireless Mouse", Quantity = 2, Price = 25.99m, Status = "Shipped", OrderDate = new DateTime(2024, 11, 15) },
            new Order { Id = 2, CustomerName = "Bob Smith", Product = "Mechanical Keyboard", Quantity = 1, Price = 89.99m, Status = "Delivered", OrderDate = new DateTime(2024, 10, 20) },
            new Order { Id = 3, CustomerName = "Charlie Brown", Product = "USB-C Hub", Quantity = 3, Price = 34.50m, Status = "Processing", OrderDate = new DateTime(2024, 11, 28) },
            new Order { Id = 4, CustomerName = "Diana Prince", Product = "27\" Monitor", Quantity = 2, Price = 299.99m, Status = "Pending", OrderDate = new DateTime(2024, 12, 01) },
            new Order { Id = 5, CustomerName = "Eve Adams", Product = "Webcam HD", Quantity = 1, Price = 59.99m, Status = "Shipped", OrderDate = new DateTime(2024, 11, 22) },
            new Order { Id = 6, CustomerName = "Frank Castle", Product = "Noise Cancelling Headphones", Quantity = 1, Price = 199.99m, Status = "Delivered", OrderDate = new DateTime(2024, 09, 10) },
            new Order { Id = 7, CustomerName = "Grace Hopper", Product = "External SSD 1TB", Quantity = 2, Price = 129.99m, Status = "Processing", OrderDate = new DateTime(2024, 12, 05) },
        };

        /// <summary>
        /// GET all orders.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return Ok(Orders);
        }

        /// <summary>
        /// GET a single order by ID.
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = Orders.FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound(new { Message = $"Order with Id {id} not found." });
            return Ok(order);
        }


        [HttpGet("Healthy")]
        public ActionResult Healthy()
        {
           
            return Ok();
        }


        //[HttpGet("Healthy-Ok")]
        //public ActionResult HealthyOK()
        //{

        //    return Ok();
        //}





    }

    /// <summary>
    /// Order model for hardcoded data.
    /// </summary>
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
    }
}
