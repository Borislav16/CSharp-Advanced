using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
            var user = users.FindById(drivingLicenseNumber);
            if (user != null)
            {
                return String.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);
            }

            IUser newUser = new User(firstName, lastName, drivingLicenseNumber);
            users.AddModel(newUser);
            return String.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            if (vehicleType != nameof(CargoVan) && vehicleType != nameof(PassengerCar))
            {
                return String.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);
            }

            var vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle != null)
            {
                return String.Format(OutputMessages.LicensePlateExists, licensePlateNumber);
            }
            IVehicle newVehicle;
            if (vehicleType == nameof(CargoVan))
            {
                newVehicle = new CargoVan(brand, model, licensePlateNumber);
            }
            else
            {
                newVehicle = new PassengerCar(brand, model, licensePlateNumber);
            }
            vehicles.AddModel(newVehicle);
            return String.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            var route = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length == length);
            if (route != null)
            {
                return String.Format(OutputMessages.RouteExisting, startPoint, endPoint, length);
            }
            route = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length < length);
            if (route != null)
            {
                return String.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);
            }
            int routeId = routes.GetAll().Count() + 1;
            route = new Route(startPoint, endPoint, length, routeId);
            routes.AddModel(route);
            route = routes.GetAll().FirstOrDefault(r => r.StartPoint == startPoint && r.EndPoint == endPoint && r.Length > length);
            if (route != null)
            {
                route.LockRoute();
            }


            return String.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);
        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {
            var user = users.FindById(drivingLicenseNumber);
            if (user.IsBlocked)
            {
                return String.Format(OutputMessages.UserBlocked, drivingLicenseNumber);
            }
            var vehicle = vehicles.FindById(licensePlateNumber);
            if (vehicle.IsDamaged)
            {
                return String.Format(OutputMessages.VehicleDamaged, licensePlateNumber);
            }
            var route = routes.FindById(routeId);
            if (route.IsLocked)
            {
                return String.Format(OutputMessages.RouteLocked, routeId);
            }
            vehicle.Drive(route.Length);

            if (isAccidentHappened)
            {
                if (!vehicle.IsDamaged)
                {
                    vehicle.ChangeStatus();
                }
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
            var damagedVehicles = this.vehicles
                .GetAll()
                .Where(v => v.IsDamaged == true)
                .OrderBy(v => v.Brand)
                .ThenBy(v => v.Model);

            int vehiclesCount = 0;

            if (damagedVehicles.Count() < count)
            {
                vehiclesCount = damagedVehicles.Count();
            }
            else
            {
                vehiclesCount = count;
            }

            var selectedVehicles = damagedVehicles.ToArray().Take(vehiclesCount);

            foreach (var vehicle in selectedVehicles)
            {
                vehicle.ChangeStatus();
                vehicle.Recharge();
            }

            return string.Format(OutputMessages.RepairedVehicles, vehiclesCount);
        }


        public string UsersReport()
        {
            var allUsers = users
                .GetAll()
                .OrderByDescending(u => u.Rating)
                .ThenBy(u => u.LastName)
                .ThenBy(u => u.FirstName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*** E-Drive-Rent ***");
            foreach (var user in allUsers)
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
