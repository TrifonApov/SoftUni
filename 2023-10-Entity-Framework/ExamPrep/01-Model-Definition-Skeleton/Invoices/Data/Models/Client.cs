using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string NumberVat { get; set; }

        public ICollection<Invoice> Invoices { get; set; }

<<<<<<< HEAD
        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
=======
        public ICollection<Address> Addresses { get; set; }

        public ICollection<ProductClient> ProductsClients { get; set; }
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
    }
}