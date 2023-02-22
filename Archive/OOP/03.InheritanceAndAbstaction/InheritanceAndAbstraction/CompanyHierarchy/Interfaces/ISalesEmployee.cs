namespace CompanyHierarchy.Interfaces
{
    using Models.Sales;
    using System.Collections.Generic;

    public interface ISalesEmployee
    {
        ICollection<Product> SetOfProduct { get; set; }
        void AddProduct(Product product);
        void AddProducts(Product[] products);
        void RemoveProduct(Product product);
        void RemoveProducts(Product[] products); 
    }
}