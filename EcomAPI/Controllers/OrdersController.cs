using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = new List<object>
        {
            new { Id = 1, UserId = 101, Product = "iPhone 15", Amount = 79999, Status = "Confirmed", CreatedAt = DateTime.UtcNow.AddDays(-1) },
            new { Id = 2, UserId = 102, Product = "MacBook Air", Amount = 95000, Status = "Pending", CreatedAt = DateTime.UtcNow.AddHours(-5) },
            new { Id = 3, UserId = 101, Product = "AirPods Pro", Amount = 24999, Status = "Confirmed", CreatedAt = DateTime.UtcNow.AddHours(-2) },
            new { Id = 4, UserId = 103, Product = "Apple Watch", Amount = 35000, Status = "Shipped", CreatedAt = DateTime.UtcNow }
        };
            return Ok(orders);
        }

        [HttpGet("/all")] // GET /api/Orders
        public IActionResult AllOrders()
        {
            // Example implementation
            var orders = new List<string> { "OrderA", "OrderB", "OrderC" };
            return Ok(orders);
        }

        [HttpGet("/healthy")] // GET /api/Orders
        public IActionResult Healthy()
        {
            // Example implementation
           
            return Ok();
        }
    }
}
