namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            CategoriesProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; } = null!;

        public int? BuyerId { get; set; }
<<<<<<< HEAD
        public User Buyer { get; set; } = null!;
=======
        public User? Buyer { get; set; }
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6

        public ICollection<CategoryProduct> CategoriesProducts { get; set; }
    }
}