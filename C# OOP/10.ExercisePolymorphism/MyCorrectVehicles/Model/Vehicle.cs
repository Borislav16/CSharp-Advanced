using MyCorrectVehicles.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCorrectVehicles.Model
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        public Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }
        public double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double consumedFuel = FuelConsumption + increasedConsumption;
            if (FuelQuantity > consumedFuel * distance)
            {
                FuelQuantity -= consumedFuel * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }

        public virtual void Refuel(double amount) => FuelQuantity += amount;

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }

    }
}
