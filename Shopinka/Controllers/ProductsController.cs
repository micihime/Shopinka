using Microsoft.AspNetCore.Mvc;
using Shopinka.Models;
using System.Collections.Generic;

namespace Shopinka.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var items = new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Arónia osudu 1",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.99M,
                    Description = "Vášeň ukrytá v čokoláde."
                },
                new Product
                {
                    Id = 2,
                    Name = "Arónia osudu 2",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 2.99M,
                    Description = "Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
                }
            };
            return Ok(items);
        }

        // GET: api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = new Product
            {
                Id = id,
                Name = "Arónia osudu",
                ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                Price = 1.99M,
                Description = "Vášeň ukrytá v čokoláde. Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
            };

            return Ok(item);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Product item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return NoContent();
        }
    }
}