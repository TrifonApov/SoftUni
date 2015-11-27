namespace CompanyHierarchy.Models.Sales
{
    using System;

    public class Product
    {
        private string productName;
        private DateTime date;
        private decimal price;

        public Product(string productName, DateTime date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get { return this.productName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Product name cannot be null or empty.");
                }
                this.productName = value;
            }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Price cannot be negative.");
                }
                this.price = value;
            }
        }
    }
}