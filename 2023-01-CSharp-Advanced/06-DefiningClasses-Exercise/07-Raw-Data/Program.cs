using System.Reflection;

namespace _07_Raw_Data
{
    public class Program
    {
        static void Main(string[] args)
        {
            int carsCount = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                double cargoWeight = double.Parse(tokens[3]);
                string cargoType = tokens[4];
                Cargo cargo = new Cargo(cargoType, cargoWeight);

                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);
                Tire tire1 = new Tire(tire1Age, tire1Pressure);
                
                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);
                Tire tire2 = new Tire(tire2Age, tire2Pressure);

                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);
                Tire tire3 = new Tire(tire3Age, tire3Pressure);

                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);
                Tire tire4 = new Tire(tire4Age, tire4Pressure);

                cars.Add(
                    new Car(
                        model, 
                        engine, 
                        cargo, 
                        new List<Tire>
                        {
                            tire1, tire2, tire3, tire4
                        }));
            }

            string filter = Console.ReadLine();
            IEnumerable<Car> result;
            if (filter == "fragile")
            {
                // print all cars, whose cargo is "fragile" and have a pressure of a single tire < 1
                result = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1));
            }
            else
            {
                // print all cars, whose cargo is "flammable" and have engine power > 250.
                result = cars.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250);
            }

            foreach (Car car in result)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}