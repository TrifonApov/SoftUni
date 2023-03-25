using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database();
        }

        [TearDown]
        public void TearDown()
        {
            database= null;
        }

        [Test]
        public void CreatePersonTest()
        {
            Person person = new Person(1, "userName");

            Assert.That(1, Is.EqualTo(person.Id));
            Assert.That("userName", Is.EqualTo(person.UserName));
        }

        [Test]
        public void CreateDatabaseTest()
        {
            Person person1 = new Person(1, "1");
            Person person2 = new Person(2, "2");
            Person person3 = new Person(3, "3");
            Person[] people = new Person[] { person1, person2, person3 };

            Database database = new Database(people);

            Assert.That(people.Length, Is.EqualTo(database.Count));
        }

        [Test]
        public void AddPerson()
        {
            long id = 1;
            string name = "Person 1";
            Person person = new Person(id, name);

            database.Add(person);
            Person foundPerson = database.FindByUsername(name);

            Assert.That(1, Is.EqualTo(database.Count));
            Assert.That(foundPerson, Is.EqualTo(person));
        }

        [Test]
        public void AddMoreThanCapacityShouldThrowsException()
        {
            Person[] people = new Person[16]
            {
                new Person(1, "1"), new Person(2, "2"), new Person(3, "3"), new Person(4, "4"),
                new Person(5, "5"), new Person(6, "6"), new Person(7, "7"), new Person(8, "8"),
                new Person(9, "9"), new Person(10, "10"), new Person(11, "11"), new Person(12, "12"),
                new Person(13, "13"), new Person(14, "14"), new Person(15, "15"), new Person(16, "16")
            };

            database = new Database(people);

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "17")));

            Assert.That(exception.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddPersonWithSameIdShouldThrowException()
        {
            database = new Database(new Person(1, "1"));
            Person newPerson = new Person(1, "2");

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(newPerson));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this Id!"));
        }

        public void AddPersonWithSameUsernameShouldThrowException()
        {
            database = new Database(new Person(1, "username"));
            Person newPerson = new Person(2, "username");

            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.Add(newPerson));

            Assert.That(exception.Message, Is.EqualTo("There is already user with this username!"));
        }

        [Test]
        public void FindUserByUsernameTest()
        {
            database = new Database(
                new Person(1, "1"), new Person(2, "2"), 
                new Person(3, "3"), new Person(4, "4"));

            Person foundPerson = database.FindByUsername("3");

            Assert.That(foundPerson.Id, Is.EqualTo(3));
        }

        [Test]
        public void FindUserByNullOrEmptyShouldThrowException()
        {
            string name = null;
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(name));

            Assert.That(exception.ParamName, Is.EqualTo("Username parameter is null!"));
        }

        [Test]
        public void FindByUserameNoExistingUseShouldThrowException()
        {
            InvalidOperationException exception =
                Assert.Throws<InvalidOperationException>(() => database.FindByUsername("NoSuchUsername"));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this username!"));
        }

        [Test]
        public void FindUserByIdTest()
        {
            database = new Database(
                new Person(1, "1"), new Person(2, "2"),
                new Person(3, "3"), new Person(4, "4"));

            Person foundPerson = database.FindById(3);

            Assert.That(foundPerson.UserName, Is.EqualTo("3"));
        }

        [Test]
        public void FindUserByNegativeIdShouldThrowException()
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(-1));

            Assert.That(exception.ParamName, Is.EqualTo("Id should be a positive number!"));
        }

        [Test]
        public void FindByIdNoExistingUseShouldThrowException()
        {
            database = new Database(new Person(1, "1"), new Person(2, "2"));
            
            var exception = Assert.Throws<InvalidOperationException>(() => database.FindById(3));

            Assert.That(exception.Message, Is.EqualTo("No user is present by this ID!"));
        }
    }
}