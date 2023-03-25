
namespace Database.Tests;

using NUnit.Framework;

public class DatabaseTests
{
    private Database database;

    [SetUp]
    public void Setup()
    {
        database = new Database();
    }

    [TearDown]
    public void TearDown()
    {
        database = null;
    }

    [Test]
    public void AddItemTest()
    {
        database.Add(42);
        int addedItem = database.Fetch()[0];


        Assert.That(1, Is.EqualTo(database.Count));
        Assert.That(42, Is.EqualTo(addedItem));
    }

    [Test]
    public void DatabaseAddMoreThanCapacityTest()
    {
        database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);

        InvalidOperationException exeption =
            Assert.Throws<InvalidOperationException>(() => database.Add(17));

        Assert.That(exeption.Message, Is.EqualTo("Array's capacity must be exactly 16 integers!"));
    }

    [Test]
    public void CreateDatabaseTest()
    {
        database = new Database(1, 2, 3, 4, 5);

        Assert.That(5, Is.EqualTo(database.Count));
    }

    [Test]
    public void RemoveItemTest()
    {
        database = new Database(1, 2, 3);
        int initialCount = database.Count;

        database.Remove();

        Assert.That(database.Count, Is.EqualTo(initialCount - 1));

    }

    [Test]
    public void RemoveItemFromEmptyDatabase()
    {
        database = new Database();

        InvalidOperationException exception =
            Assert.Throws<InvalidOperationException>(() => database.Remove());

        Assert.That(exception.Message, Is.EqualTo("The collection is empty!"));
    }

    [Test]
    public void FetchTest()
    {
        database = new Database(1, 202, 33, 4, 9855, 246, 42);
        int[] fetched = database.Fetch();

        Assert.That(new int[] { 1, 202, 33, 4, 9855, 246, 42 }, Is.EquivalentTo(fetched));
    }
}