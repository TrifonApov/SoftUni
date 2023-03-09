using System;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double increaseConsumption;
    private double tankCapacity;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increaseConsumption)
    {
        TankCapacity = tankCapacity;
        FuelQuantity = fuelQuantity;
        FuelConsumption = fuelConsumption;

        this.increaseConsumption = increaseConsumption;
    }

    public double FuelQuantity
    {
        get => fuelQuantity;
        private set
        {
            if (value > tankCapacity) fuelQuantity = 0;
            
            else fuelQuantity = value;
        }
    }

    public double FuelConsumption
    {
        get => fuelConsumption;
        private set => fuelConsumption = value;
    }

    public double TankCapacity
    {
        get => tankCapacity;
        private set => tankCapacity = value;
    }

    public string Drive(double distance, bool isIncreasedConsumption = false)
    {
        
        double totalConsumption = isIncreasedConsumption 
            ? fuelConsumption + increaseConsumption 
            : fuelConsumption;
        
        if (totalConsumption * distance > FuelQuantity)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }
        
        fuelQuantity -= totalConsumption * distance;

        return $"{this.GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
        if (quantity + fuelQuantity > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {quantity} fuel in the tank");
        }
        FuelQuantity += quantity;
    }

    public override string ToString()
        => $"{this.GetType().Name}: {FuelQuantity:F2}";
}