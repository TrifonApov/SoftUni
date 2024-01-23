using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;
using Trucks.Extensions;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Data;
    using Trucks.Data.Models;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            StringBuilder result = new StringBuilder();

            var importDespatchersDTOs = xmlString.DeserializeFromXml<ImportDespatcherDTO[]>("Despatchers");
            var despatchersToAdd = new List<Despatcher>();

            foreach (ImportDespatcherDTO despatcherDTO in importDespatchersDTOs)
            {
                if (!IsValid(despatcherDTO) || string.IsNullOrEmpty(despatcherDTO.Position))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var despatcherToAdd = new Despatcher()
                {
                    Name = despatcherDTO.Name,
                    Position = despatcherDTO.Position
                };

                foreach (ImportTruckDTO truckDTO in despatcherDTO.Trucks)
                {
                    if (!IsValid(truckDTO))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }
                    despatcherToAdd.Trucks.Add(new Truck
                    {
                        RegistrationNumber = truckDTO.RegistrationNumber,
                        VinNumber = truckDTO.VinNumber,
                        TankCapacity = truckDTO.TankCapacity,
                        CargoCapacity = truckDTO.CargoCapacity,
                        CategoryType = (CategoryType)truckDTO.CategoryType,
                        MakeType = (MakeType)truckDTO.MakeType
                    });
                }

                despatchersToAdd.Add(despatcherToAdd);
                result.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcherToAdd.Name, despatcherToAdd.Trucks.Count));
            }

            context.AddRange(despatchersToAdd);
            context.SaveChanges();
            
            return result.ToString().TrimEnd();
        }
        
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            StringBuilder result = new StringBuilder();

            var importClientsDTOs = jsonString.DeserializeFromJson<ImportClientDTO[]>();

            var clientsToAdd = new List<Client>();
            var trucksIds = context.Trucks.Select(x => x.Id);

            foreach (var importClientDTO in importClientsDTOs)
            {
                if (!IsValid(importClientDTO) ||
                    importClientDTO.Type == "usual")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var clientToAdd = new Client
                {
                    Name = importClientDTO.Name,
                    Nationality = importClientDTO.Nationality,
                    Type = importClientDTO.Type
                };

                foreach (var truckId in importClientDTO.Trucks.Distinct())
                {
                    if (!trucksIds.Contains(truckId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;   
                    }
                    
                    clientToAdd.ClientsTrucks.Add(new ClientTruck()
                    {
                        TruckId = truckId
                    });
                }

                clientsToAdd.Add(clientToAdd);
                result.AppendLine(string.Format(SuccessfullyImportedClient, clientToAdd.Name,
                    clientToAdd.ClientsTrucks.Count));
            }

            context.AddRange(clientsToAdd);
            context.SaveChanges();

            return result.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}