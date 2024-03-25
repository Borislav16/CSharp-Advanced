namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            car = new("BMW", "X5", 10, 86);
        }

        [Test]
        public void CarConstructorShouldWorkCorrectly()
        {
            
            int expectedResult = 0;
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarConstructorMakePropShouldWorkCorrectly()
        {
            Car car = new("BMW", "X5", 10.3, 86);
            string expectedResult = "BMW";
            string actualResult = car.Make;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorMakePropShouldThrowExceptionWhenMakeIsNullOrEmpty(string make)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, "X5", 10.3, 86));

            Assert.AreEqual("Make cannot be null or empty!" , exception.Message);
        }

        [Test]
        public void CarConstructorModelPropShouldWorkCorrectly()
        {
            Car car = new("BMW", "X5", 10.3, 86);
            string expectedResult = "X5";
            string actualResult = car.Model;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarConstructorModelPropShouldThrowExceptionWhenModelIsNullOrEmpty(string model)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", model, 10.3, 86));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [Test]
        public void CarConstructorFuelConsumptionPropShouldWorkCorrectly()
        {
            Car car = new("BMW", "X5", 10.3, 86);
            double expectedResult = 10.3;
            double actualResult = car.FuelConsumption;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-1)]
        [TestCase(-1324.5)]
        public void CarConstructorFuelConsumptionPropShouldThrowExceptionWhenFuelConsumptionIsNegative(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "X5", fuelConsumption, 86));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarConstructorFuelCapacityShouldWorkCorrectly()
        {
            Car car = new("BMW", "X5", 10.3, 86.3);
            double expectedResult = 86.3;
            double actualResult = car.FuelCapacity;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1324.5)]
        public void CarConstructorFuelCapacityPropShouldThrowExceptionWhenFuelCapacityIsNegativeOrZero(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "X5", 10.3, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarRefuelMethodShouldWorkCorrectly()
        {
            car.Refuel(25);
            double expectedResult = 25;
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-1324.5)]
        public void CarRefuelMethodShouldThrowExceptionWhenFuelAmountIsZeroOrNegative(double refuel)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(refuel));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarRefuelMethodShouldFuelAmountToTakeFuelCapacityWhenFuelAmountIsMoreThanFuelCapacity()
        {
            Car car = new("BMW", "X5", 10.3, 20);
            car.Refuel(25);
            double expectedResult = 20;
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void CarDriveMethodShouldWorkCorrectly()
        {
            car.Refuel(25);
            car.Drive(25);
            
            double expectedResult = 22.5;
            double actualResult = car.FuelAmount;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void CarDriveMethodShouldThrowExceptionWhenFuelNeededIsMoreThanFuelAmount()
        {
            car.Refuel(1);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => car.Drive(30));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}