using NUnit.Framework;
using System.Linq;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        Garage garageSetup;
        [SetUp]
        public void Setup()
        {
            garageSetup = new Garage(1);
        }

        [Test]
        public void GarageConstructorShouldWorkCorrectly()
        {
            garageSetup.Capacity = 2;
            bool isTrue = garageSetup.AddVehicle(new Vehicle("opel", "astra", "chbh"));
            Assert.AreEqual(1, garageSetup.Vehicles.Count);
            Assert.AreEqual(true, isTrue);

            garageSetup.Capacity = 2;
            var garage = new Garage(1);
            var vehicle1 = new Vehicle("opel", "astra", "Abc");
            var vehicle2 = new Vehicle("opel", "astra", "Abc");


            garage.AddVehicle(vehicle1);
            bool result = garage.AddVehicle(vehicle2);


            Assert.AreEqual(false, result);
            Assert.AreEqual(1, garage.Vehicles.Count);


            var garage2 = new Garage(1);
            var vehicle3 = new Vehicle("opel", "astra", "Abc");
            var vehicle4 = new Vehicle("opel", "astra", "Abcf");


            garage2.AddVehicle(vehicle3);
            bool result2 = garage2.AddVehicle(vehicle4);


            Assert.AreEqual(false, result);
            Assert.AreEqual(1, garage2.Vehicles.Count);

        }

        [Test]
        public void MethodShouldWorkCorrectly()
        {
            garageSetup.Capacity = 2;
            bool isTrue = garageSetup.AddVehicle(new Vehicle("opel", "astra", "chbh"));
            Assert.AreEqual(1, garageSetup.Vehicles.Count);
            Assert.AreEqual(true, isTrue);

            bool isFalse = garageSetup.AddVehicle(new Vehicle("opel", "astra", "chbh"));
            Assert.AreEqual(false, isFalse);
        }

        [Test]
        public void MethodChargeVehiclesShouldWorkCorrectly()
        {

            var garage = new Garage(3);
            var vehicle1 = new Vehicle("opel", "astra", "chbh") { BatteryLevel = 50 };
            var vehicle2 = new Vehicle("opel", "astra", "chbhf") { BatteryLevel = 80 };
            var vehicle3 = new Vehicle("opel", "astra", "chbf") { BatteryLevel = 30 };

            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);


            int charged = garage.ChargeVehicles(70);


            Assert.AreEqual(2, charged);
            Assert.AreEqual(100, vehicle1.BatteryLevel);
            Assert.AreEqual(80, vehicle2.BatteryLevel);
            Assert.AreEqual(100, vehicle3.BatteryLevel);
        }

        [Test]
        public void MethodDriveVehicleShouldWorkCorrectly()
        {
            bool isTrue = garageSetup.AddVehicle(new Vehicle("opel", "astra", "chbh"));
            //if 1
            garageSetup.DriveVehicle("chbh", 150, true);
            Vehicle vehicle = garageSetup.Vehicles.Find(v => v.LicensePlateNumber == "chbh");
            Assert.AreEqual(false, vehicle.IsDamaged);
            //if 2
            vehicle.IsDamaged = true;
            garageSetup.DriveVehicle("chbh", 150, true);
            Assert.AreEqual(true, vehicle.IsDamaged);
            //if 3
            vehicle.IsDamaged = false;
            vehicle.BatteryLevel = 10;
            garageSetup.DriveVehicle("chbh", 150, true);
            Assert.AreEqual(false, vehicle.IsDamaged);

            //true
            vehicle.BatteryLevel = 100;
            garageSetup.DriveVehicle("chbh", 10, true);
            Assert.AreEqual(90, vehicle.BatteryLevel);
            Assert.AreEqual(true, vehicle.IsDamaged);
            
            //false
            vehicle.BatteryLevel = 100;
            vehicle.IsDamaged = false;
            garageSetup.DriveVehicle("chbh", 10, false);
            Assert.AreEqual(90, vehicle.BatteryLevel);
            Assert.AreEqual(false, vehicle.IsDamaged);

        }
        [Test]
        public void MethodRepairVehicleShouldWorkCorrectly()
        {

            var garage = new Garage(2);
            var vehicle1 = new Vehicle("opel", "astra", "chbh");
            vehicle1.IsDamaged = true;
            var vehicle2 = new Vehicle("opel", "astra", "chbhf");
            vehicle2.IsDamaged = false;

            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);

            string repairMessage = garage.RepairVehicles();

            Assert.AreEqual("Vehicles repaired: 1", repairMessage);
            Assert.AreEqual(false, vehicle1.IsDamaged);
            Assert.AreEqual(false, vehicle2.IsDamaged);

        }

    }
}