using Microsoft.AspNetCore.Mvc;
using Shopinka.Api.Dtos;
using Shopinka.Api.V2.Controllers;
using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;
using Xunit;

namespace Shopinka.Test
{

    public class ProductsControllerV2Tests
    {
        private readonly ProductsController _controller;
        private readonly IProductService _service;

        public ProductsControllerV2Tests()
        {
            _service = new ProductFakeService();
            _controller = new ProductsController(_service);
        }

        #region GET ALL
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var dto = new PagingDto { PageNumber = 1, PageSize = 5 };
            // Act
            var okResult = _controller.Get(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsRequestedNumberOfItems()
        {
            // Arrange
            int pageSize = 5;
            var dto = new PagingDto { PageNumber = 1, PageSize = pageSize };
            // Act
            var okResult = _controller.Get(dto) as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(pageSize, items.Count);
        }

        [Fact]
        public void Get_NotExistingPage_ReturnsOkResult()
        {
            // Arrange
            int pageNumber = 30;
            var dto = new PagingDto { PageNumber = pageNumber, PageSize = 5 };
            // Act
            var okResult = _controller.Get(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_NotExistingPage_ReturnsEmpty()
        {
            // Arrange
            int pageNumber = 30;
            var dto = new PagingDto { PageNumber = pageNumber, PageSize = 5 };
            // Act
            var okResult = _controller.Get(dto) as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Empty(items);
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

        #region PUT
        [Fact]
        public void Put_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = 1000;
            var testDesc = "test desc";
            var dto = new ProductDto { Id = testId, Description = testDesc };
            // Act
            var badReqResult = _controller.Put(testId, dto);
            // Assert
            Assert.IsType<BadRequestResult>(badReqResult as BadRequestResult);
        }

        [Fact]
        public void Put_DifferrentIdInDto_ReturnsBadRequestResult()
        {
            // Arrange
            var testId = 1;
            var testDesc = "test desc";
            var dto = new ProductDto { Id = testId++, Description = testDesc };
            // Act
            var badReqResult = _controller.Put(testId, dto);
            // Assert
            Assert.IsType<BadRequestResult>(badReqResult as BadRequestResult);
        }

        [Fact]
        public void Put_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var testId = 1;
            var testDesc = "test desc";
            var dto = new ProductDto { Id = testId, Description = testDesc };
            // Act
            var noContentResult = _controller.Put(testId, dto);
            // Assert
            Assert.IsType<NoContentResult>(noContentResult as NoContentResult);
        }
        #endregion
    }
}