using System;
using System.Collections.Generic;
using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

internal class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        string[] carTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));

        string[] truckTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle truck = new Truck(double.Parse(carTokens[1]), double.Parse(carTokens[2]));

        int commands = int.Parse(reader.ReadLine());
        for (int i = 0; i < commands; i++)
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            
        }
    }
}