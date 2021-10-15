using System.ComponentModel.DataAnnotations;

namespace Shopinka.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string ImageUri { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
