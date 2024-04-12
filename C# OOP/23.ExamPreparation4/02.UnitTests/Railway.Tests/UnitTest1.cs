namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            RailwayStation railwayStation = new RailwayStation("name");
            Assert.AreEqual("name", railwayStation.Name);
            Assert.AreEqual(0, railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);
        }

        [Test]
        public void NamePropertyShouldThrowExxception()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new RailwayStation(string.Empty));


            ArgumentException exception2 = Assert.Throws<ArgumentException>(()
                => new RailwayStation(" "));

            ArgumentException exception3 = Assert.Throws<ArgumentException>(()
                => new RailwayStation("  "));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);
            Assert.AreEqual("Name cannot be null or empty!", exception2.Message);
            Assert.AreEqual("Name cannot be null or empty!", exception3.Message);
        }

        [Test]
        public void MethodNewArrivalShouldWorkCorrectly()
        {
            RailwayStation railwayStation = new RailwayStation("name");
            railwayStation.NewArrivalOnBoard("bus");
            Assert.AreEqual("bus", railwayStation.ArrivalTrains.Peek());
            railwayStation.NewArrivalOnBoard("car");
            Assert.AreEqual(2, railwayStation.ArrivalTrains.Count());
            railwayStation.ArrivalTrains.Dequeue();
            Assert.AreEqual("car", railwayStation.ArrivalTrains.Peek());
        }

        [Test] 
        public void MethodTrainHasArrivedShouldWorkCorrectly()
        {
            RailwayStation railwayStation = new RailwayStation("name");
            railwayStation.NewArrivalOnBoard("bus");
            railwayStation.NewArrivalOnBoard("car");
            string result = railwayStation.TrainHasArrived("bus");
            Assert.AreEqual($"bus is on the platform and will leave in 5 minutes.", result);
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
            result = railwayStation.TrainHasArrived("bus");
            Assert.AreEqual($"There are other trains to arrive before bus.", result);
        }

        [Test]
        public void MethodTrainHasLelfShouldWork()
        {
            RailwayStation railwayStation = new RailwayStation("name");
            railwayStation.NewArrivalOnBoard("bus");
            railwayStation.NewArrivalOnBoard("car");
            railwayStation.TrainHasArrived("bus");
            railwayStation.TrainHasArrived("car");
            bool result = railwayStation.TrainHasLeft("bus");
            Assert.IsTrue(result);

            result = railwayStation.TrainHasLeft("bus");
            Assert.IsFalse(result);
        }
    }
}