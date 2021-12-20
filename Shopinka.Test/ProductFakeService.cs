using Shopinka.Core.Services;
using Shopinka.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shopinka.Test
{
    public class ProductFakeService : IProductService
    {
        private readonly List<Product> _products;

        public ProductFakeService()
        {
            _products = new List<Product>()
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

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.Where(a => a.Id == id)
                .FirstOrDefault();
        }

        public void UpdateDesc(int id, string desc)
        {
            var p = _products.Where(a => a.Id == id)
                .FirstOrDefault();

            if (p != null)
                p.Description = desc;
        }
    }
}
