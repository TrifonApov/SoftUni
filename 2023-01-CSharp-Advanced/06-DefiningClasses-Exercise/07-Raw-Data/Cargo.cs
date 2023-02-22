namespace _07_Raw_Data
{
    public class Cargo
    {
        private string type;
        private double weight;

        public Cargo(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type { get; set; }
        public double Weight { get; set; }
    }
}
