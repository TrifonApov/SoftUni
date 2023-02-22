namespace PcCatalog
{
    using System;

    public class Component
    {
        private string type;
        private string details;
        private decimal price;

        public Component(string type, decimal price, string details)
            : this (type, price)
        {
            this.Details = details;
        }

        public Component(string type, decimal price)
        {
            this.Type = type;
            this.Price = price;
        }

        
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Type should be at least 3 symbols");
                }
                this.type = value;
            }
        }

        public string Details
        {
            get { return this.details; }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length < 3)
                {
                    throw new ArgumentException("Details should be at least 3 symbols. Or no details at all");
                }
                this.details = value;
            }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Price should be positive");
                }
                this.price = value;
            }
        }
    }
}