using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private double defaultFuelConsumption;
        private double fuelConsumption;
        private double fuel;
        private int horsePower;

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }


        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }


        public virtual double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = DefaultFuelConsumption; }
        }


        public double DefaultFuelConsumption
        {
            get { return defaultFuelConsumption; }
            set { defaultFuelConsumption = 1.25; }
        }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
