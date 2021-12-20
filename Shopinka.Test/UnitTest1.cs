using Microsoft.AspNetCore.Mvc;
using Shopinka.Controllers;
using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;
using Xunit;

namespace Shopinka.Test
{

    public class UnitTest1
    {
        private readonly ProductsController _controller;
        private readonly IProductService _service;

        public UnitTest1()
        {
            _service = new ProductFakeService();
            _controller = new ProductsController(_service);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(13, items.Count);
        }
    }
}
