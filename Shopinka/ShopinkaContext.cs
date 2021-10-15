using Microsoft.EntityFrameworkCore;
using Shopinka.Models;

namespace Shopinka
{
    public class ShopinkaContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=ShopinkaDb;Trusted_Connection=True;");
        }
    }
}
