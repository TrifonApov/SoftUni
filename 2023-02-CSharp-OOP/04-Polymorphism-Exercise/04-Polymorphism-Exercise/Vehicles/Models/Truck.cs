namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double IncreasConsumption = 1.6;

    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption, IncreasConsumption)
    {
    }
}