namespace BookShop
{
    using System;

    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string title, string author, decimal price)
        {
            this.Title = title;
            this.Author = author;
            this.Price = price;
        }

        public string Title
        {
            get { return this.title; }
            set
            {
                if (ValidateString(value))
                {
                    throw new ArgumentException("Title cannot be null or empty.");
                }
                this.title = value;
            }
        }

        public string Author
        {
            get { return this.author; }
            set
            {
                if (ValidateString(value))
                {
                    throw new ArgumentException("Author cannot be null or empty.");
                }
                this.author = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            set
            {
                if (ValidatePrice(value))
                {
                    throw new ArgumentOutOfRangeException(
                        paramName: "price",
                        message: "Price cannot be negative.");
                }
                this.price = value;
            }
        }

        private bool ValidateString(string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        private bool ValidatePrice(decimal priceToValidate)
        {
            return priceToValidate < 0;
        }

        public override string ToString()
        {
            return string.Format("-Type: {0}\n-Title: {1}\n-Author: {2}\n-Price: {3}",
                this.GetType().Name,
                this.Title,
                this.Author,
                this.Price.ToString("F2"));
        }
    }
}
