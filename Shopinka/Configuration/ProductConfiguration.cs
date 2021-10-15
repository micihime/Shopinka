using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopinka.Models;

namespace Shopinka.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasData
            (
                new Product
                {
                    Id = 1,
                    Name = "Arónia osudu",
                    ImageUri = "https://elezi.sk/wp-content/uploads/2019/08/photo_21-02-2019_14_18_01-upr_1.jpg",
                    Price = 1.99M,
                    Description = "Vášeň ukrytá v čokoláde. Čokoláda je jedným z najväčších pokušení aké si človek len môže predstaviť. "
                }
            );
        }
    }
}
