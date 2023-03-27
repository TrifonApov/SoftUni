using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        public Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set => size = value;
        }

        public double Price
        {
            get { return price; }
            private set
            {
                double modifier = 1;
                switch (size)
                {
                    case "Middle": modifier = 2.0 / 3.0; break;
                    case "Small": modifier = 1.0 / 3.0; break;
                }
                price = value * modifier;
            }
        }

        public override string ToString()
        {
            return $"{name} ({size}) - {price:F2} lv";
        }
    }
}