namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private TextBook textBook;
        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook("The Neverending Story", "Michael Ende", "Fantasy");
            library = new UniversityLibrary();
        }

        [Test]
        public void Test01_Constructor()
        {
            Assert.That(0, Is.EqualTo(library.Catalogue.Count));
        }

        [Test]
        public void Test02_AddTextBookToLibrary()
        {
            library.AddTextBookToLibrary(textBook);

            Assert.That(1, Is.EqualTo(library.Catalogue.Count));
            Assert.That(1, Is.EqualTo(library.Catalogue[0].InventoryNumber));
            Assert.That("The Neverending Story", Is.EqualTo(library.Catalogue[0].Title));
        }

        [Test]
        public void Test03_LoanTextBook()
        {
            library.AddTextBookToLibrary(textBook);

            string bookLoaned = library.LoanTextBook(1, "Trifon");
            
            Assert.That(bookLoaned, Is.EqualTo($"{textBook.Title} loaned to {"Trifon"}."));
        }

        [Test]
        public void Test04_BookIsAllreadeyLoaned()
        {
            library.AddTextBookToLibrary(textBook);

            string bookLoanedFirstTime = library.LoanTextBook(1, "Trifon");
            string bookLoanedSecondTime = library.LoanTextBook(1, "Trifon");

            Assert.That(bookLoanedSecondTime, Is.EqualTo($"{"Trifon"} still hasn't returned {textBook.Title}!"));
        }

        [Test]
        public void Test05_ReturnTextBook()
        {
            library.AddTextBookToLibrary(textBook);
            library.LoanTextBook(1, "Trifon");

            string returnedBook = library.ReturnTextBook(1);
            
            Assert.That(returnedBook, Is.EqualTo($"{textBook.Title} is returned to the library."));
        }
    }
}