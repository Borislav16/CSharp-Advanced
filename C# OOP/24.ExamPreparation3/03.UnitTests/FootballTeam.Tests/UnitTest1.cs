using NUnit.Framework;
using System;
using System.Globalization;
using System.Numerics;

namespace FootballTeam.Tests
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
            FootballTeam footballTeam = new FootballTeam("name", 20);
            Assert.AreEqual("name", footballTeam.Name);
            Assert.AreEqual(20, footballTeam.Capacity);
            Assert.AreEqual(0, footballTeam.Players.Count);
        }

        [Test]
        public void PropertiesShouldThrowException()
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new FootballTeam(string.Empty, 20));
            Assert.AreEqual("Name cannot be null or empty!", exception.Message);

            ArgumentException exception2 = Assert.Throws<ArgumentException>(()
                => new FootballTeam(null, 20));
            Assert.AreEqual("Name cannot be null or empty!", exception2.Message);


            ArgumentException exception4 = Assert.Throws<ArgumentException>(()
                => new FootballTeam("name", 14));
            Assert.AreEqual("Capacity min value = 15", exception4.Message);

            ArgumentException exception5 = Assert.Throws<ArgumentException>(()
                => new FootballTeam("name", -100));
            Assert.AreEqual("Capacity min value = 15", exception5.Message);


            ArgumentException exception6 = Assert.Throws<ArgumentException>(()
                => new FootballTeam("name", 0));
            Assert.AreEqual("Capacity min value = 15", exception6.Message);
        }


        [Test]
        public void MethodAddNewPlayerShouldWork()
        {
            FootballTeam footballTeam = new FootballTeam("name", 15);
            string result = footballTeam.AddNewPlayer(new FootballPlayer("name", 16, "Midfielder"));
            Assert.AreEqual($"Added player name in position Midfielder with number 16", result);
            Assert.AreEqual(1, footballTeam.Players.Count);
        }

        [Test]
        public void MethodAddNewPlayerShouldThrowException()
        {
            FootballTeam footballTeam = new FootballTeam("name", 15);
            for (int i = 0; i < 3; i++)
            {
                footballTeam.AddNewPlayer(new FootballPlayer("name", 16, "Midfielder"));
                footballTeam.AddNewPlayer(new FootballPlayer("name2", 15, "Goalkeeper"));
                footballTeam.AddNewPlayer(new FootballPlayer("name3", 14, "Midfielder"));
                footballTeam.AddNewPlayer(new FootballPlayer("name4", 13, "Forward"));
                footballTeam.AddNewPlayer(new FootballPlayer("name5", 12, "Forward"));
            }
            string result = footballTeam.AddNewPlayer(new FootballPlayer("name", 16, "Midfielder"));
            Assert.AreEqual("No more positions available!", result);
            Assert.AreEqual(15, footballTeam.Players.Count);
        }

        [Test]
        public void MethodPickPlayerShouldWork()
        {
            FootballTeam footballTeam = new FootballTeam("name", 15);
            FootballPlayer footballPlayer = new FootballPlayer("name", 16, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            var player = footballTeam.PickPlayer("name");
            Assert.AreEqual(footballPlayer, player);
            Assert.AreEqual(footballPlayer.Name, player.Name);
            Assert.AreEqual(footballPlayer.PlayerNumber, player.PlayerNumber);
            Assert.AreEqual(footballPlayer.Position, player.Position);

            var player2 = footballTeam.PickPlayer("goshko");
            Assert.AreEqual(null, player2);
        }

        [Test]
        public void MethodPlayerScore()
        {
            FootballTeam footballTeam = new FootballTeam("name", 15);
            FootballPlayer footballPlayer = new FootballPlayer("name", 16, "Midfielder");
            footballTeam.AddNewPlayer(footballPlayer);
            string result = footballTeam.PlayerScore(16);
            Assert.AreEqual(1, footballPlayer.ScoredGoals);
            Assert.AreEqual($"name scored and now has 1 for this season!", result);
        }
    }
}