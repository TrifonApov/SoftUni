using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.capacity = capacity;
        }
        
        public List<Car> Cars { get; set; }
        
        public int Count => this.Cars.Count;
        public string AddCar(Car car)
        {
            if (this.Cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.Cars.Count + 1 > capacity)
            {
                return "Parking is full!";
            }

            this.Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }
        public string RemoveCar(string registrationNumber)
        {

            if (!this.Cars.Any(c => c.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            this.Cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
            return $"Successfully removed {registrationNumber}";
        }
        public Car GetCar(string registrationNumber)
        {
            return this.Cars.First(c => c.RegistrationNumber == registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                this.Cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
            }
        }

    }
}
