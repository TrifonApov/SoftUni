namespace Vehicles.Models;

internal class Car : Vehicle
{
    private const double IncreasConsumption = 0.9;
    
    public Car(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption, IncreasConsumption)
    {
    }

}