using System;
using System.Collections.Generic;
using System.Linq;

namespace _08_Car_Salesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = GenerateEnginesList();
            List<Car> cars = GenerateCarsList(engines);

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
            
        }

        private static List<Car> GenerateCarsList(List<Engine> engines)
        {
            List<Car> cars = new();
            int carsCount = int.Parse(Console.ReadLine());
            // "{model} {engine} {weight} {color}"

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                Engine engine = engines.First(e => e.Model == tokens[1]);

                string color = null;
                int weight = int.MinValue;

                Car car = new Car(model, engine);

                if (tokens.Length == 3)
                {
                    if (!int.TryParse(tokens[2], out weight))
                    {
                        color = tokens[2];
                    }
                }
                else if (tokens.Length == 4)
                {
                    weight = int.Parse(tokens[2]);
                    color = tokens[3];
                }

                car.Weight = weight;
                car.Color = color;

                cars.Add(car);
            }


            return cars;
        }

        static List<Engine> GenerateEnginesList()
        {
            List<Engine> engines = new();
            int enginesCount = int.Parse(Console.ReadLine());
            //"{model} {power} {displacement} {efficiency}"
            for (int i = 0; i < enginesCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string engineModel = tokens[0];
                int enginePower = int.Parse(tokens[1]);
                int displacement = int.MinValue;
                string efficiency = null;

                Engine engine = new Engine(engineModel, enginePower);

                if (tokens.Length == 3)
                {
                    if (!int.TryParse(tokens[2], out displacement))
                    {
                        efficiency = tokens[2];
                    }
                }
                else if (tokens.Length == 4)
                {
                    displacement = int.Parse(tokens[2]);
                    efficiency = tokens[3];
                }

                engine.Displacement = displacement;
                engine.Efficiency = efficiency;

                engines.Add(engine);
            }
            return engines;
        }

    }
}