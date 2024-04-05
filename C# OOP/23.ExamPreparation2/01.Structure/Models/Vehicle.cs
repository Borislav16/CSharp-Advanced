using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {

        protected Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            this.batteryLevel = 100;
        }
        private string brand;

        public string Brand
        {
            get { return brand; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        private string model;

        public string Model
        {
            get { return model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        private double maxMileage;

        public double MaxMileage
        {
            get { return maxMileage; }
            private set { maxMileage = value; }
        }


        private string licensePlateNumber;

        public string LicensePlateNumber
        {
            get { return licensePlateNumber; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        private int batteryLevel;

        public int BatteryLevel
        {
            get { return batteryLevel; }
            private set { batteryLevel = value; }
        }


        private bool isDamaged;

        public bool IsDamaged
        {
            get { return isDamaged; }
            private set { isDamaged = value; }
        }

        public void Drive(double mileage)
        {
            if(this.GetType() == typeof(CargoVan))
            {
                batteryLevel -= 5;
            }
            double percentage = mileage / MaxMileage;
            batteryLevel = batteryLevel - (int)Math.Round(100 * percentage);
        }

        public void Recharge()
        {
            batteryLevel = 100;
        }

        public void ChangeStatus()
        {
            if (isDamaged == true)
            {
                isDamaged = false;
            }
            else
            {
                isDamaged = true;
            }
        }

        public override string ToString()
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(isDamaged? "damaged" : "OK")}";
        }

    }
}
