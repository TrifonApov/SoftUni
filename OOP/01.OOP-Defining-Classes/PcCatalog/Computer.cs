namespace PcCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Computer
    {
        private string name;
        private ICollection<Component> components;
        private decimal price;

        public Computer(string name)
        {
            this.Name = name;
            this.Components = new HashSet<Component>();
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public ICollection<Component> Components
        {
            get { return this.components; }
            set { this.components = value; }
        }

        public decimal Price
        {
            get
            {
                return this.Components.Sum(c => c.Price);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(new string('-', 50));
            output.AppendLine("Computer name: " + this.Name);
            output.AppendLine("-->Components:");

            foreach (var component in this.Components)
            {
                output.AppendLine("   -->Type: " + component.Type);
                output.AppendLine("       - Price: " + component.Price.ToString("C", new CultureInfo("bg-BG")));

                if (!string.IsNullOrEmpty(component.Details))
                {
                    output.AppendLine("       - Details: " + component.Details);
                }
            }

            output.AppendLine("-->Total Price: " + this.Price.ToString("C", new CultureInfo("bg-BG")));


            return output.ToString();
        }
    }
}
