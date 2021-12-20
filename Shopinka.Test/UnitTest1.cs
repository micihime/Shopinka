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

        #region GET ALL
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
        #endregion

        #region GET BY ID
        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = 1000;
            // Act
            var notFoundResult = _controller.Get(testId);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = _controller.Get(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 1;
            // Act
            var okResult = _controller.Get(testId) as OkObjectResult;
            // Assert
            Assert.IsType<Product>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Product).Id);
        }
        #endregion
    }
}