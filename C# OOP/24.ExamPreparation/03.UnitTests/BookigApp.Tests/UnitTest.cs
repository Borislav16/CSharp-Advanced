using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("name", 5);
        }

        [Test]
        public void ConstructorShouldWorkCorrectly()
        {
            string name = "name";
            int category = 5;
            Assert.AreEqual(name, hotel.FullName);
            Assert.AreEqual(category, hotel.Category);
        }

        [TestCase(null)]
        [TestCase("  ")]
        [TestCase(" ")]
        public void PropertyFullNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, 5));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(200)]
        public void PropertyCategoryShouldThrowException(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("name", category));
        }

        [Test]
        public void MethodAddRoomShouldWorkCorrectly()
        {
            Room room = new Room(1, 1);
            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void MethodBookRoomShouldThrowExceptionWhenAdultsAreLessThan0()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 2, 5, 5));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-1, 2, 5, 5));
        }

        [Test]
        public void MethodBookRoomShouldThrowExceptionWhenChildrenAreLessThan0()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -2, 5, 5));
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, -1, 5, 5));
        }

        [Test]
        public void MethodBookRoomShouldThrowExceptionWhenResidenceDurationIsLessThan1()
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(1, 2, -5, 5));
        }

        [Test]
        public void MethodBookRoomShouldWorkCorrectly()
        {
            Room room = new Room(5, 3);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 2, 5, 25);
            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(15, hotel.Turnover);
        }
    }
}