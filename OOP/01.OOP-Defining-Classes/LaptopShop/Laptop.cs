namespace LaptopShop
{
    using System;
    using System.Text;

    public class Laptop
    {
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private string ram;
        private string graphicsCard;
        private string hdd;
        private string screen;
        private Batery batery;

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;
        }

        public Laptop(string model, decimal price, string manufacturer)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
        }

        public Laptop(string model, decimal price, string manufacturer, Batery batery)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Batery = batery;
        }

        public Laptop(string model, decimal price, string manufacturer, string processor, string ram, string graphicsCard, string hdd, string screen, Batery batery)
        {
            this.Model = model;
            this.Price = price;
            this.Manufacturer = manufacturer;
            this.Processor = processor;
            this.Ram = ram;
            this.GraphicsCard = graphicsCard;
            this.Hdd = hdd;
            this.Screen = screen;
            this.Batery = batery;
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

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price should be positive");
                }
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.manufacturer = value;
                }
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.processor = value;
                }
            }
        }

        public string Ram
        {
            get { return this.ram; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.ram = value;
                }
            }
        }

        public string GraphicsCard
        {
            get { return this.graphicsCard; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.graphicsCard = value;
                }
            }
        }

        public string Hdd
        {
            get { return this.hdd; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.hdd = value;
                }
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.screen = value;
                }
            }
        }

        public Batery Batery
        {
            get { return this.batery; }
            set { this.batery = value; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Model: " + this.Model);
            output.AppendLine("Manufacturer: " + (string.IsNullOrEmpty(this.Manufacturer) ? "No data" : this.Manufacturer));
            output.AppendLine("Proocessor: " + (string.IsNullOrEmpty(this.Processor) ? "No data" : this.Processor));
            output.AppendLine("RAM: " + (string.IsNullOrEmpty(this.Ram) ? "No data" : this.Ram));
            output.AppendLine("Graphics card: " + (string.IsNullOrEmpty(this.GraphicsCard) ? "No data" : this.GraphicsCard));
            output.AppendLine("HDD: " + (string.IsNullOrEmpty(this.Hdd) ? "No data" : this.Hdd));
            output.AppendLine("Screen: " + (string.IsNullOrEmpty(this.Screen) ? "No data" : this.Screen));
            if (this.Batery != null)
            {
                output.AppendLine("Battery: " + this.Batery.Model);
                output.AppendLine("Battery life: " + this.Batery.Life + " hours");
            }
            else
            {
                output.AppendLine("Battery: No data");
                output.AppendLine("Battery life: No data");
            }
            output.AppendLine("Price: " + this.Price.ToString("C"));

            return output.ToString();
        }
    }
}