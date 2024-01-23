using Invoices.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 9)]
        public string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public decimal Price { get; set; }

        public CategoryType CategoryType { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; }

    }
}
