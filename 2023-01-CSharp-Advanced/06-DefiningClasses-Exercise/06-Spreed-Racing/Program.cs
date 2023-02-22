using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_Spreed_Racing
{
    public class Program
    {
        static void Main(string[] args)
        {
            //2
            //AudiA4 23 0.3
            //Drive BMW-M2 56
            List<Car> cars = new List<Car>();
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumptionFor1km = double.Parse(tokens[2]);

                if (cars.Any(c => c.Model == model))
                {
                    continue;
                }
                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carToDrive = tokens[1];
                double distanceToTravel = double.Parse(tokens[2]);

                if (cars.Find(c => c.Model == carToDrive).IsFuelEnough(distanceToTravel))
                {
                    double consumption = cars.Find(c => c.Model == carToDrive).FuelConsumptionPerKilometer;
                    cars.Find(c => c.Model == carToDrive).TravelledDistance += distanceToTravel;
                    cars.Find(c => c.Model == carToDrive).FuelAmount -= consumption * distanceToTravel;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }


                command = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }
    }
}