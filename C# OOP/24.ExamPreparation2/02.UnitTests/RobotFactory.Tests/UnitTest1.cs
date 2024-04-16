using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace RobotFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            string name = "Goshko";
            int capacity = 100;
            Factory factory = new Factory(name, capacity);
            Assert.AreEqual(name, factory.Name);
            Assert.AreEqual(capacity, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);
        }

        [Test]
        public void MethodProduceRobotShouldWorkCorrectly()
        {
            string name = "Goshko";
            int capacity = 1;
            Factory factory = new Factory(name, capacity);
            string result = factory.ProduceRobot("model", 10.5, 17);
            Assert.AreEqual($"Produced --> Robot model: model IS: 17, Price: 10.50", result);

            result = factory.ProduceRobot("model", 10.5, 17);
            Assert.AreEqual($"The factory is unable to produce more robots for this production day!", result);
        }

        [Test]
        public void MethodProduceSupplementsShouldWorkCorrectly()
        {
            string name = "Goshko";
            int capacity = 1;
            Factory factory = new Factory(name, capacity);
            string result = factory.ProduceSupplement(name, 16);
            Assert.AreEqual($"Supplement: Goshko IS: 16", result);
            result = factory.ProduceSupplement("Toshko", 18);
            Assert.AreEqual($"Supplement: Toshko IS: 18", result);
        }

        [Test]
        public void MethodUpgradeRobotShouldWorkCorrectly()
        {
            string name = "Goshko";
            int capacity = 1;
            Factory factory = new Factory(name, capacity);
            Robot robot = new Robot("model", 10.5, 17);
            Supplement supplement = new Supplement(name, 16);
            bool result = factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(false, result);


            name = "Goshko";
            capacity = 1;
            factory = new Factory(name, capacity);
            robot = new Robot("model", 10.5, 16);
            supplement = new Supplement(name, 16);
            robot.Supplements.Add(supplement);
            result = factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(false, result);


            name = "Goshko";
            capacity = 1;
            factory = new Factory(name, capacity);
            robot = new Robot("model", 10.5, 16);
            supplement = new Supplement(name, 16);
            result = factory.UpgradeRobot(robot, supplement);
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, robot.Supplements.Count);
        }

        [Test]
        public void UpgradeRobotSuccessful()
        {
            Factory factory = new Factory("SpaceX", 10);

            factory.ProduceRobot("Robo-3", 2500, 22);
            factory.ProduceSupplement("SpecializedArm", 22);

            var actualResult = factory.UpgradeRobot(factory.Robots.FirstOrDefault(), factory.Supplements.FirstOrDefault());

            Assert.AreEqual(true, actualResult);
        }
        [Test]
        public void MethodSellRobotShouldWorkCorrectly()
        {
            string name = "Goshko";
            int capacity = 1;
            Factory factory = new Factory(name, capacity);
            Robot robot = new Robot("model", 10.5, 17);
            Robot robot2 = new Robot("model", 11.5, 16);
            Robot robot3 = new Robot("model", 8, 15);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Robot result = factory.SellRobot(11);
            Assert.AreEqual(result, robot);
        }

        [Test]
        public void MethodSellRobotShouldWorkCorrectly2()
        {
            string name = "Goshko";
            int capacity = 1;
            Factory factory = new Factory(name, capacity);
            Robot robot = new Robot("model", 10.5, 17);
            Robot robot2 = new Robot("model", 11.5, 16);
            Robot robot3 = new Robot("model", 8, 15);
            factory.Robots.Add(robot);
            factory.Robots.Add(robot2);
            factory.Robots.Add(robot3);

            Robot result = factory.SellRobot(10.5);
            Assert.AreEqual(result, robot);
        }


        
    }
}