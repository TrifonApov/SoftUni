using System.Collections.Generic;
using System.Linq;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories.Contracts;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private readonly List<IVehicle> vehicles;

        public VehicleRepository()
        {
            vehicles = new List<IVehicle>();
        }

        public void AddModel(IVehicle model)
        {
            vehicles.Add(model);
        }

        public bool RemoveById(string identifier)
        {
            return vehicles.Remove(vehicles.Single(vehicle => vehicle.LicensePlateNumber == identifier));
        }

        public IVehicle FindById(string identifier)
        {
            return vehicles.FirstOrDefault(vehicle => vehicle.LicensePlateNumber == identifier);

        }

        public IReadOnlyCollection<IVehicle> GetAll()
        {
            return vehicles.AsReadOnly();
        }
    }
}