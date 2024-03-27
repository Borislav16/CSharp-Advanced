namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorConstructorShouldWorkCorrectly()
        {
            string expectedName = "Gosho";
            int expectedDamage = 10;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage );
            Assert.AreEqual(expectedHP, warrior.HP);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("  ")]
        public void WarriorConstructorShouldThrowExceptionWhenNameNullOrWhiteSpace(string name)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior(name, 10, 100));

            Assert.AreEqual("Name should not be empty or whitespace!", exception.Message);
        }

        [TestCase(0)]
        [TestCase(-10000)]
        [TestCase(-16)]
        public void WarriorConstructorShouldThrowExceptionWhenDamageIsNotPositive(int damage)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior("Gosho", damage, 100));

            Assert.AreEqual("Damage value should be positive!", exception.Message);
        }

        [TestCase(-103)]
        [TestCase(-10000)]
        [TestCase(-16)]
        public void WarriorConstructorShouldThrowExceptionWhenHPIsNegative(int hp)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Warrior("Gosho", 10, hp));

            Assert.AreEqual("HP should not be negative!", exception.Message);
        }

        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAtackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAtackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }

        [TestCase(30)]
        [TestCase(25)]
        [TestCase(10)]
        public void AttackMethodShouldThrowExceptionWhenHpIs30OrLess(int hp)
        {
            Warrior attacker = new("Pesho", 10, hp);
            Warrior defender = new("Gosho", 5, 90);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [TestCase(30)]
        [TestCase(25)]
        [TestCase(10)]
        public void AttackMethodShouldThrowExceptionWhenWarriorHPIs30OrLess(int hp)
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, hp);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Enemy HP must be greater than 30 in order to attack him!", exception.Message);
        }

        
        [Test]
        public void AttackMethodShouldThrowExceptionWhenHpIsLessThanWarriorDamage()
        {
            Warrior attacker = new("Pesho", 10, 35);
            Warrior defender = new("Gosho", 45, 100);
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("You are trying to attack too strong enemy", exception.Message);
        }

        [Test]
        public void AttackMethodShouldThrowExceptionWhenWarriorHpIsLessThanDamage()
        {
            Warrior attacker = new("Pesho", 100, 100);
            Warrior defender = new("Gosho", 45, 90);

            attacker.Attack(defender);
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, defender.HP);
        }
    }
}