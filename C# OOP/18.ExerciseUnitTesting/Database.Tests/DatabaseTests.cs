namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;
        [SetUp]
        public void CreateConstructor()
        {
            database = new Database(1, 3, 4, 6);

        }

        [Test]
        public void TestConstructorCount()
        {
            //Arrange 
            int expectedResult = 4;
            //Act
            database = new Database(1, 3, 4, 6);
            int actualResult = database.Count;
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CreateDatabaseShouldAddElementsCorrectly(int[] data)
        {
            //Arrange - TestCase

            //Act
            database = new Database(data);
            int[] actual = database.Fetch();

            //Assert
            Assert.AreEqual(data, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreateDatabaseShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database = new Database(data));

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedResult = 4;
            int actualResult = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(-3)]
        [TestCase(0)]
        public void DatabaseAddMethodShouldIncreaseCount(int num)
        {
            int expectedResult = 5;

            database.Add(num);

            Assert.AreEqual(expectedResult, database.Count);
        }
        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void DatabaseAddMethodShouldAddElementsCorrectly(int[] data)
        {
            database = new Database();

            foreach (var number in data)
            {
                database.Add(number);
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 })]
        public void DatabaseAddMethodShouldThrowExceptionWhenCountIsMoreThan16(int[] data)
        {
            for (int i = 0; i < 12; i++)
            {
                database.Add(i);
            }

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Add(16), "Array's capacity must be exactly 16 integers!");

            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void DatabaseRemoveMethodShouldDecreaseCount()
        {
            int expectedResult = 3;

            database.Remove();

            Assert.AreEqual(expectedResult, database.Count);
        }
        [Test]
        public void DatabaseRemoveMethodShouldRemoveElementsCorrectly()
        {
            int[] expectedResult = Array.Empty<int>();

            for (int i = 0; i < 4; i++)
            {
                database.Remove();
            }

            int[] actualResult = database.Fetch();

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DatabaseRemoveMethodShouldThrowExceptionWhenCountIsZero()
        {
            for (int i = 0; i < 4; i++)
            {
                database.Remove();
            }
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
                => database.Remove());
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void DatabaseFetchMethodShouldReturnCorrectData(int[] data)
        {
            database = new Database(data);
            int[] actualResult = database.Fetch();

            Assert.AreEqual(data, actualResult);
        }
    }
}
