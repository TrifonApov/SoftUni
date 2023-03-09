namespace Vehicles.Models.Interfaces;

public interface IVehicle
{
    double FuelQuantity { get; }
    
    double FuelConsumption { get; }
    
    double TankCapacity { get; }

    string Drive(double distance, bool isIncreasedConsumption = false);
    
    void Refuel(double quantity);
}