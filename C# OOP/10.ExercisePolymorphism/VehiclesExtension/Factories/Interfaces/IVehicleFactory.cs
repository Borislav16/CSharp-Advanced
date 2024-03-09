using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclesExtension.Model.Interfaces;

namespace VehiclesExtension.Factories;

public interface IVehicleFactory
{
    public IVehicle Create(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
}
