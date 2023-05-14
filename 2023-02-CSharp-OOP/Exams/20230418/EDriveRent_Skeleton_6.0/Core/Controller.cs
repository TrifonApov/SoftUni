using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private UserRepository users;
        private VehicleRepository vehicles;
        private RouteRepository routes;

        public Controller()
        {
            users = new UserRepository();
            vehicles = new VehicleRepository();
            routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (users.FindById(drivingLicenseNumber) != null)
            {
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser user = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(user);

            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != "PassengerCar" && vehicleType != "CargoVan")
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);

            if (vehicles.FindById(licensePlateNumber) != null)
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);

            IVehicle vehicle;
            switch (vehicleType)
            {
                case "PassengerCar":
                    vehicle = new PassengerCar(brand, model, licensePlateNumber);
                    break;
                default:
                    vehicle = new CargoVan(brand, model, licensePlateNumber);
                    break;
            }

            vehicles.AddModel(vehicle);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            if (routes
                    .GetAll()
                    .FirstOrDefault(r => r.StartPoint == startPoint
                                       && r.EndPoint == endPoint
                                       && r.Length == length) != null)
                return string.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);

            if (routes
                    .GetAll()
                    .FirstOrDefault(r => r.StartPoint == startPoint
                                         && r.EndPoint == endPoint
                                         && r.Length < length) != null)
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);


            IRoute route = new Route(startPoint, endPoint, length, routes.GetAll().Count + 1);
            IRoute longerRoute = routes
                .GetAll()
                .FirstOrDefault(r => r.StartPoint == startPoint
                                     && r.EndPoint == endPoint
                                     && r.Length > length);
            
            if (longerRoute != null)
            {
                longerRoute.LockRoute();
            }

            routes.AddModel(route);

            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            IUser user = users.FindById(drivingLicenseNumber);
            IVehicle vehicle = vehicles.FindById(licensePlateNumber);
            IRoute route = routes.FindById(routeId);

            if (user.IsBlocked)
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);

            if (vehicle.IsDamaged)
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);

            if (route.IsLocked)
                return string.Format(OutputMessages.RouteLocked, routeId);

            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                vehicle.ChangeStatus();
                user.DecreaseRating();
            }
            else
            {
                user.IncreaseRating();
            }

            return vehicle.ToString();

        }

        public string RepairVehicles(int count)
        {
            List<IVehicle> vehiclesToRepair = vehicles
                .GetAll()
                .Where(v => v.IsDamaged)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model)
                .Take(count)
                .ToList();
            foreach (IVehicle vehicle in vehiclesToRepair)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }
            return string.Format(OutputMessages.RepairedVehicles, vehiclesToRepair.Count);
        }

        public string UsersReport()
        {
            var vehiclesToReport = users
                .GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");

            foreach (IUser user in vehiclesToReport)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}