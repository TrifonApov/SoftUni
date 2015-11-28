namespace CompanyHierarchy.Models.Sales
{
    using System;

    public class Product
    {
        private string productName;
        private DateTime dateOfSale;
        private decimal price;

        public Product(string productName, DateTime dateOfSale, decimal price)
        {
            this.ProductName = productName;
            this.DateOfSale = dateOfSale;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                Validation.Validate.IsNullOrEmpty("Product name", value);
                this.productName = value;
            }
        }

        public DateTime DateOfSale
        {
            get { return this.dateOfSale; }
            set
            {
                Validation.Validate.DateOfSale("Date of sale", value);
                this.dateOfSale = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                Validation.Validate.IsNegative("Product price", value);
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Product: {0}, Date of sale: {1:dd-MM-yyyy} Price: {2:C2}",
                this.ProductName,
                this.DateOfSale,
                this.Price);
        }
    }
}