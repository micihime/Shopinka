using Microsoft.AspNetCore.Mvc;
using Moq;
using Shopinka.Api.Controllers;
using Shopinka.Api.Dtos;
using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Shopinka.Test
{

    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _service;

        public ProductsControllerTests()
        {
            _service = new Mock<IProductService>();
        }

        #region CONSTANTS AS INPUTS TO METHODS

        private const int testId = 1;
        private const int notExistingTestId = 1000;
        private const int pageSize = 5;
        private const int pageNumber = 1;
        private const int notExistingPageNumber = 30;
        private const string testDesc = "test desc";
        #endregion

        #region SERVICE SETUP METHODS

        private List<Product> getSampleProducts()
        {
            return new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Arónia osudu",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.99M,
                    Description = "Vášeň ukrytá v čokoláde. Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
                },
                new Product
                {
                    Id = 2,
                    Name = "Karamelový anjelik",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 0.69M,
                    Description = "Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
                },
                new Product
                {
                    Id = 3,
                    Name = "Rumová chrumka",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 2.69M,
                    Description = "Chrumkavá vášeň ukrytá v čokoláde. Jemná príchuť kubánskeho rumu."
                },
                new Product
                {
                    Id = 4,
                    Name = "Jahodová chrumka",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.69M,
                    Description = "Chrumkavá vášeň ukrytá v čokoláde. Dotyk jahôdok. "
                },
                new Product
                {
                    Id = 5,
                    Name = "Čili chrumka",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 0.39M,
                    Description = "Vášeň ukrytá v čokoláde. Okoreňte si svoj život. "
                },
                new Product
                {
                    Id = 6,
                    Name = "Kávička v čokoláde",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 2.39M,
                    Description = "Vášeň ukrytá v čokoláde. Espresso shot v čokoláde. "
                },
                new Product
                {
                    Id = 7,
                    Name = "Double trouble",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.39M,
                    Description = "Prekvapenie."
                },
                new Product
                {
                    Id = 8,
                    Name = "Agent Provocateur",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 0.79M,
                    Description = "Zážitok."
                },
                new Product
                {
                    Id = 9,
                    Name = "Mandľové praliné",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 2.79M,
                    Description = "Najpredávanejšia pralinka."
                },
                new Product
                {
                    Id = 10,
                    Name = "Lieskovoorieškové praliné",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.79M,
                    Description = "Luxusná variácia najpredávanejšej pralinky."
                },
                new Product
                {
                    Id = 11,
                    Name = "Čože je to borovička",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 0.49M,
                    Description = "Čokoládová ganache s dotykom najkvalitnejšej borovičky."
                },
                new Product
                {
                    Id = 12,
                    Name = "Čože je to slivovička",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 2.49M,
                    Description = "Čokoládová ganache s dotykom najkvalitnejšej slivovičky."
                },
                new Product
                {
                    Id = 13,
                    Name = "Harmančekové pohladenie",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.49M,
                    Description = "Herbal infusion. Upokojujúca chuť harmančeka v sladkom objatí bielej čokolády."
                }
            };
        }

        private List<Product> getPagedProducts()
        {
            return getSampleProducts().Take(pageSize).ToList();
        }

        private List<Product> getEmpty() { return new List<Product>(); }

        private Product getProduct()
        {
            return new Product
            {
                Id = 1,
                Name = "Arónia osudu",
                ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                Price = 1.99M,
                Description = "Vášeň ukrytá v čokoláde. Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
            };
        }

        private Product getNull() { return null; }
        #endregion

        #region GET ALL

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            _service.Setup(x => x.GetAll())
                .Returns(getSampleProducts);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            _service.Setup(x => x.GetAll())
                .Returns(getSampleProducts);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(13, items.Count);
        }
        #endregion

        #region GET ALL (PAGED)

        [Fact]
        public void GetPaged_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var dto = new PagingDto { PageNumber = pageNumber, PageSize = pageSize };
            _service.Setup(x => x.GetAll(dto.PageNumber, dto.PageSize))
                .Returns(getPagedProducts);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetPaged_WhenCalled_ReturnsRequestedNumberOfItems()
        {
            // Arrange
            var dto = new PagingDto { PageNumber = pageNumber, PageSize = pageSize };
            _service.Setup(x => x.GetAll(dto.PageNumber, dto.PageSize))
                .Returns(getPagedProducts);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get(dto) as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(pageSize, items.Count);
        }

        [Fact]
        public void GetPaged_NotExistingPage_ReturnsOkResult()
        {
            // Arrange
            var dto = new PagingDto { PageNumber = notExistingPageNumber, PageSize = pageSize };
            _service.Setup(x => x.GetAll(dto.PageNumber, dto.PageSize))
                .Returns(getEmpty);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get(dto);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetPaged_NotExistingPage_ReturnsEmpty()
        {
            // Arrange
            var dto = new PagingDto { PageNumber = notExistingPageNumber, PageSize = pageSize };
            _service.Setup(x => x.GetAll(dto.PageNumber, dto.PageSize))
                .Returns(getEmpty);
            var _controller = new ProductsController(_service.Object);
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
            _service.Setup(x => x.GetById(notExistingTestId))
               .Returns(getNull);
            var _controller = new ProductsController(_service.Object);
            // Act
            var notFoundResult = _controller.Get(notExistingTestId);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            _service.Setup(x => x.GetById(testId))
               .Returns(getProduct);
            var _controller = new ProductsController(_service.Object);
            // Act
            var okResult = _controller.Get(testId);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            _service.Setup(x => x.GetById(testId))
               .Returns(getProduct);
            var _controller = new ProductsController(_service.Object);
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
            var dto = new ProductDto { Id = notExistingPageNumber, Description = testDesc };
            _service.Setup(x => x.UpdateDesc(dto.Id, dto.Description))
               .Returns(false);
            var _controller = new ProductsController(_service.Object);
            // Act
            var badReqResult = _controller.Put(notExistingPageNumber, dto);
            // Assert
            Assert.IsType<BadRequestResult>(badReqResult as BadRequestResult);
        }

        [Fact]
        public void Put_DifferrentIdInDto_ReturnsBadRequestResult()
        {
            // Arrange
            var dto = new ProductDto { Id = notExistingPageNumber, Description = testDesc };
            //_service.Setup(x => x.UpdateDesc(dto.Id, dto.Description))
            //   .Returns(false);
            var _controller = new ProductsController(_service.Object);
            // Act
            var badReqResult = _controller.Put(testId, dto);
            // Assert
            Assert.IsType<BadRequestResult>(badReqResult as BadRequestResult);
        }

        [Fact]
        public void Put_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var dto = new ProductDto { Id = testId, Description = testDesc };
            _service.Setup(x => x.UpdateDesc(dto.Id, dto.Description))
               .Returns(true);
            var _controller = new ProductsController(_service.Object);
            // Act
            var noContentResult = _controller.Put(testId, dto);
            // Assert
            Assert.IsType<NoContentResult>(noContentResult as NoContentResult);
        }
        #endregion
    }
}