using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopinka.Models;
using System.Linq;

namespace Shopinka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopinkaContext _context;

        public ProductsController()
        {
            _context = new ShopinkaContext();
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Products.ToList());
        }

        // GET: api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Products.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}