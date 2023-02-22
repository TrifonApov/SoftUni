using System.Text;

namespace _08_Car_Salesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.Append(this.Engine.ToString());
            string weight = this.Weight > 0 ? this.Weight.ToString() : "n/a";
            string color = this.Color != null ? this.Color : "n/a";
            sb.AppendLine($"  Weight: {weight}");
            sb.Append($"  Color: {color}");
            return sb.ToString();
        }
    }
}
