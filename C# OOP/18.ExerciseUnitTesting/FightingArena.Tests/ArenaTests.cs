namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorShouldWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        
        }

        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new Warrior("Gosho", 5, 100);
            arena.Enroll(warrior);
            
            int actualResult = arena.Count;

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void EnrollMethodShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("Gosho", 5, 100);
            
            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(warrior, arena.Warriors.Single());
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenThisWarriorIsInWarrios()
        {
            Warrior warrior = new Warrior("Gosho", 5, 100);

            arena.Enroll(warrior);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior));

            Assert.AreEqual("Warrior is already enrolled for the fights!", exception.Message);
        
        }

        [Test]
        public void FightMethodShouldWorkCorrectly()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);
            arena.Enroll(defender);
            arena.Fight("Pesho", "Gosho");

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 35;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [Test]
        public void FightNethodShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(defender);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", exception.Message);
        }

        [Test]
        public void ArenaFightShouldThrowExceptionIfDefenderNotFound()
        {
            Warrior attacker = new("Gosho", 15, 100);
            Warrior defender = new("Pesho", 5, 50);

            arena.Enroll(attacker);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
               => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", exception.Message);
        }
    }
}
