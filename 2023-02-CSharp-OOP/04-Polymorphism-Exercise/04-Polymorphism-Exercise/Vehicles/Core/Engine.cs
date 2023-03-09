using System;
using System.Collections.Generic;
using System.Linq;
using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    private IVehicleFactory vehicleFactory;

    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;

        vehicles = new List<IVehicle>();
    }

    public void Run()
    {
        // car
        vehicles.Add(CreateVehicle());

        // truck
        vehicles.Add(CreateVehicle());

        // bus
        vehicles.Add(CreateVehicle());


        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch (ArgumentException exception)
            {
                writer.WriteLine(exception.Message);
            }
        }

        foreach (IVehicle vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }

    private IVehicle CreateVehicle()
    {
        string[] tokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string vehicleType = tokens[0];
        double fuelQuantity = double.Parse(tokens[1]);
        double consumption = double.Parse(tokens[2]);
        double tankCapacity = double.Parse(tokens[3]);

        return vehicleFactory.Create(vehicleType, fuelQuantity, consumption, tankCapacity);
    }

    private void ProcessCommand()
    {
        string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string commandType = commandTokens[0];
        string vehicleType = commandTokens[1];

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);
        if (vehicle == null)
        {
            throw new ArgumentException("Invalid type of vehicle.");
        }

        switch (commandType)
        {
            case "Drive":
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
                break;
            case "DriveEmpty":
                double emptyDistance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(emptyDistance, true));
                break;
            case "Refuel":
                double quantity = double.Parse(commandTokens[2]);
                vehicle.Refuel(quantity);
                break;
        }
    }
}