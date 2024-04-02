namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook textBook;
        UniversityLibrary library;
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("title", "author", "category");
            library = new UniversityLibrary();
        }

        [Test]
        public void TestBookConstructrorShouldWorkCorrectly()
        {
            Assert.AreEqual("title", textBook.Title);
            Assert.AreEqual("author", textBook.Author);
            Assert.AreEqual("category", textBook.Category);

        }

        [Test]
        public void UniversityLibraryConstructorShouldWorkCorrectlyWhenEmpty()
        {
            UniversityLibrary university = new UniversityLibrary();
            Assert.AreEqual(0, university.Catalogue.Count);
        }

        [Test]
        public void MethodAddTextBookToLibraryShouldWorkCorrectly()
        {
            StringBuilder sb = new StringBuilder();
            UniversityLibrary university = new UniversityLibrary();
            string result = university.AddTextBookToLibrary(textBook);
            sb.AppendLine($"Book: title - 1");
            sb.AppendLine($"Category: category");
            sb.AppendLine($"Author: author");

            Assert.AreEqual(1, university.Catalogue.Count);
            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual("title", university.Catalogue[0].Title);
            Assert.AreEqual(sb.ToString().TrimEnd(), result);
        }

        //[Test]
        //public void LoanTextbookTests()
        //{
        //    string title = "title";
        //    library.AddTextBookToLibrary(textBook);
        //    Assert.AreEqual(textBook.Holder, null);

        //    string result = library.LoanTextBook(1, "Pesho");

        //    Assert.AreEqual(textBook.Holder, "Pesho");
        //    Assert.AreEqual(result, $"{title} loaned to Pesho.");

        //    result = library.LoanTextBook(1, "Pesho");
        //    Assert.AreEqual(result, $"Pesho still hasn't returned {textBook.Title}!");

        //}

        [Test]
        public void MethodLoanTextBookShouldWorkCorrectlyWhenTextBookHolderNotEqualToStudent()
        {
            string name = "name";
            library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(textBook.Holder, null);
            string result = library.LoanTextBook(1, name);
            Assert.AreEqual($"{textBook.Title} loaned to {name}.", result);
            library = new UniversityLibrary();
            library.AddTextBookToLibrary(textBook);
            result = library.LoanTextBook(1, name);
            Assert.AreEqual(textBook.Holder, name);
            Assert.AreEqual($"{name} still hasn't returned {textBook.Title}!", result);
        }

        [Test]
        public void MethodReturnTextBookShouldWorkCorrectly()
        {
            UniversityLibrary university = new UniversityLibrary();
            university.AddTextBookToLibrary(textBook);
            string result = university.ReturnTextBook(1);
            Assert.AreEqual("", textBook.Holder);
            Assert.AreEqual($"{textBook.Title} is returned to the library.", result);
        }

        [Test]
        public void MethodToStringShouldWorkCorrectly()
        {

            string result = library.AddTextBookToLibrary(textBook);
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: title - 1");
            sb.AppendLine($"Category: category");
            sb.AppendLine($"Author: author");

            Assert.AreEqual(sb.ToString().TrimEnd(), result);
        }

        [Test]
        public void TextBookPropertiesShoudlWorkCorrectly()
        {
            textBook.Title = "Title";
            textBook.Author = "Author";
            textBook.InventoryNumber = 2;
            textBook.Category = "Category";
            textBook.Holder = "Holder";

            Assert.AreEqual("Title", textBook.Title);
            Assert.AreEqual("Author", textBook.Author);
            Assert.AreEqual(2, textBook.InventoryNumber);
            Assert.AreEqual("Category", textBook.Category);
            Assert.AreEqual("Holder", textBook.Holder);
        }
    }
}