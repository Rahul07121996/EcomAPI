using EcomAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomAPI.Tests.Controllers
{
    public class OrdersControllerTests
    {
        private readonly OrdersController _controller;

        public OrdersControllerTests()
        {
            _controller = new OrdersController();
        }

        [Fact]
        public void GetAllOrders_ReturnsOkObjectResult_WithOrders()
        {
            // Act
            var result = _controller.GetAllOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orders = Assert.IsAssignableFrom<IEnumerable<object>>(okResult.Value);
            Assert.NotEmpty(orders);
        } 

        [Fact]
        public void AllOrders_ReturnsOkObjectResult_WithOrderNames()
        {
            // Act
            var result = _controller.AllOrders();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var orders = Assert.IsAssignableFrom<IEnumerable<string>>(okResult.Value);
            Assert.NotEmpty(orders);
        }
    }
}
