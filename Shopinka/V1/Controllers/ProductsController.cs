using Microsoft.AspNetCore.Mvc;
using Shopinka.Api.Dtos;
using Shopinka.Core.Services;

namespace Shopinka.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        // GET: api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put(int id, ProductDto product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var isSuccess = _productService.UpdateDesc(id, product.Description);

            if (isSuccess)
                return NoContent();
            else
                return BadRequest();
        }
    }
}