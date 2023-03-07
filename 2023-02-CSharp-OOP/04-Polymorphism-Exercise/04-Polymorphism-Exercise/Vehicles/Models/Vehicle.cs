using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double increaseConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increaseConsumption)
    {
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;
        this.increaseConsumption = increaseConsumption;
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        private set => fuelQuantity = value;
    }

    public double FuelConsumption
    {
        get => fuelConsumption;
        private set => fuelConsumption = value;
    }

    public string Drive(double distance)
    {
        double totalConsumption = fuelConsumption + increaseConsumption;
        if (totalConsumption * distance > FuelQuantity)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }
        
        fuelQuantity -= fuelConsumption * distance;
        return $"{this.GetType().Name} travelled {distance} km";

    }

    public void Refuel(double quantity) => fuelQuantity += quantity;

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}