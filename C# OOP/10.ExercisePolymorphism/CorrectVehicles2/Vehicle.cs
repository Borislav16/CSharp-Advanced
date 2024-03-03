using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectVehicles2
{
    public abstract class Vehicle
    {
        // consts: 
        private const double CAR_ADDITIONAL_CONSUMPTION = 0.9;
        private const double TRUCK_ADDITIONAL_CONSUMPTION = 1.6;
        private const double BUS_ADDITIONAL_CONSUMPTION = 1.4;

        private const double TRUCK_TANK_CAPACITY = 0.95;

        //fields: only one 

        private double fuelConsumption;

        // props : 
        public double FuelQuantity
        {
            get;

            private set;
        }

        public double FuelConsumptionPerKm
        {
            get
            {
                return this.fuelConsumption;
            }
            private set
            {
                if (this.GetType().Name == "Car")
                {
                    this.fuelConsumption = value + CAR_ADDITIONAL_CONSUMPTION;
                }
                else if (this.GetType().Name == "Truck")
                {
                    this.fuelConsumption = value + TRUCK_ADDITIONAL_CONSUMPTION;
                }

                else if (this.GetType().Name == "Bus")
                {

                    this.fuelConsumption = value + BUS_ADDITIONAL_CONSUMPTION;

                }
            }
        }

        public int TankCapacity
        {
            get;
            private set;
        }

        // ctor: 
        public Vehicle(double fuelQuantity, double consumptionPerKm, int tankCapacity)
        {

            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = consumptionPerKm;
            this.TankCapacity = tankCapacity;
        }

        //driving and refueling methods :

        public void Drive(double kilometers) // no change here ????
        {
            if (kilometers * this.FuelConsumptionPerKm <= this.FuelQuantity) // valid travel 
            {
                Console.WriteLine($"{this.GetType().Name} travelled {kilometers} km");

                this.FuelQuantity -= kilometers * FuelConsumptionPerKm;
            }

            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }


        public void DriveEmptyBus(double kilometers)
        {
            if (kilometers * (this.FuelConsumptionPerKm - BUS_ADDITIONAL_CONSUMPTION) <= this.FuelQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} travelled {kilometers} km");

                this.FuelQuantity -= kilometers * (FuelConsumptionPerKm - BUS_ADDITIONAL_CONSUMPTION);
            }

            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }


        public void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }

            if (liters > 0 && liters + this.FuelQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }

            if (liters > 0 && liters + this.FuelQuantity <= this.TankCapacity)
            {
                if (this.GetType().Name == "Truck")
                {
                    this.FuelQuantity += liters * TRUCK_TANK_CAPACITY;
                }

                else
                {
                    this.FuelQuantity += liters;
                }
            }
        }


        public void PrintFuelQty()
        {
            Console.WriteLine($"{this.GetType().Name}: {this.FuelQuantity:f2}");
        }
    }
}

