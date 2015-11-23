namespace LaptopShop
{
    using System;

    public class Batery
    {
        private string model;
        private double life;

        public Batery(string model, double life)
        {
            this.Model = model;
            this.Life = life;
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Model name length shoud be at least 2 symbols");
                }
                this.model = value;
            }
        }

        public double Life
        {
            get { return this.life; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price should be positive");
                }
                this.life = value;
            }
        }
    }
}