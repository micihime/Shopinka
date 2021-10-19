using Microsoft.EntityFrameworkCore;
using Shopinka.Configuration;
using Shopinka.Models;

namespace Shopinka
{
    public class ShopinkaContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ShopinkaContext(DbContextOptions<ShopinkaContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
