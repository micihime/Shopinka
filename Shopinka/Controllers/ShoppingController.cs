using Microsoft.AspNetCore.Mvc;
using Shopinka.Api.Dtos;
using Shopinka.Core.Services;

namespace Shopinka.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IProductService _productService;

        public ShoppingController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ShoppingController>
        [HttpGet]
        public IActionResult Get([FromQuery] PagingDto paging)
        {
            return Ok(_productService.GetAll(paging.PageNumber, paging.PageSize));
        }

        // GET: api/<ShoppingController>/5
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

        // PUT api/<ShoppingController>/5
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
