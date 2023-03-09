namespace Vehicles.Models;

internal class Car : Vehicle
{
    private const double IncreaseConsumption = 0.9;
    
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
        : base(fuelQuantity, fuelConsumption, tankCapacity, IncreaseConsumption)
    {
    }


}