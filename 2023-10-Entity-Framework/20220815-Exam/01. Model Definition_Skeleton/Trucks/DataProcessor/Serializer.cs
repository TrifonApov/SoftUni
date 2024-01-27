<<<<<<< HEAD
﻿using Trucks.DataProcessor.ExportDto;
using Trucks.Extensions;

namespace Trucks.DataProcessor
{
    using Data;
    using Trucks.Data.Models.Enums;
=======
﻿namespace Trucks.DataProcessor
{
    using Data;
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
<<<<<<< HEAD
            var despatchers = context
                .Despatchers
                .Where(d=>d.Trucks.Any())
                .Select(d=> new ExportDespatcherDTO
                {
                    DespatcherName = d.Name,
                    TrucksCount = d.Trucks.Count,
                    Trucks = d.Trucks
                        .Select(t=> new ExportTruckDTO
                        {
                            RegistrationNumber = t.RegistrationNumber,
                            Make = t.MakeType
                        })
                        .OrderBy(t=>t.RegistrationNumber)
                        .ToArray()
                    
                })
                .OrderByDescending(d=>d.Trucks.Length)
                .ThenBy(d=>d.DespatcherName)
                .ToArray();

            return despatchers.SerializeToXml("Despatchers").TrimEnd();
=======
            throw new NotImplementedException();
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
<<<<<<< HEAD
            var clientsWithMostTrucks = context.Clients
                .Where(c => c.ClientsTrucks.Any(ct => ct.Truck.TankCapacity >= capacity))
                .ToArray()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(cl => cl.Truck.TankCapacity >= capacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType,
                            MakeType = t.Truck.MakeType
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            var result = clientsWithMostTrucks.SerializeToJson();

            return result.TrimEnd();
=======
            throw new NotImplementedException();
>>>>>>> c516b297b9447f172fdd4545a3a62d772d4519a6
        }
    }
}
