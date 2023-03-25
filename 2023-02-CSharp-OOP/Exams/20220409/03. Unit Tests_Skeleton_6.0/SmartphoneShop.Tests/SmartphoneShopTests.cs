using System;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private Smartphone smartphone;
        private Shop shop;
        private string model = "Poco X3";
        private int maximumCharge = 100;
        private int capacity = 3;
        [SetUp]
        public void SetUp()
        {
            smartphone = new Smartphone(model, maximumCharge);
            shop = new Shop(capacity);
        }

        [Test]
        public void Test_Constructor()
        {
            Assert.That(capacity, Is.EqualTo(shop.Capacity));
        }

        [Test]
        public void Test_InvalidCapacityShouldThrown()
        {
            
            var exception = Assert.Throws<ArgumentException>(() => new Shop(-2));

            Assert.That(exception.Message, Is.EqualTo("Invalid capacity."));
        }

        [Test]
        public void Test_CountGetter()
        {
            shop.Add(smartphone);
            Assert.That(1, Is.EqualTo(shop.Count));
        }

        [Test]
        public void Test_AddPhone()
        {
            shop.Add(smartphone);
            Assert.That(1, Is.EqualTo(shop.Count));
        }

        [Test]
        public void Test_AddExistingPhoneShouldThrow()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void Test_AddMoreThanCapacityShouldThrow()
        {
            shop.Add(new Smartphone("1",maximumCharge));
            shop.Add(new Smartphone("2",maximumCharge));
            shop.Add(new Smartphone("3",maximumCharge));

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone));
        }

        [Test]
        public void Test_RemovePhone()
        {
            shop.Add(smartphone);
            shop.Remove(model);

            Assert.That(0, Is.EqualTo(shop.Count));
        }

        [Test]
        public void Test_RemoveNotExistingPhoneShouldThrow()
        {
            shop.Add(smartphone);
            
            Assert.Throws<InvalidOperationException>(()=>  shop.Remove("No such model"));
        }

        [Test]
        public void TestPhone()
        {
            shop.Add(smartphone);
            shop.TestPhone(model, 10);

            Assert.That(90, Is.EqualTo(smartphone.CurrentBateryCharge));
        }

        [Test]
        public void TestNotExistingPhoneShouldThrow()
        {
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("No such model", 1));
        }

        [Test]
        public void Test_PhoneTestWithLowBatteryShouldThrow()
        {
            smartphone = new Smartphone(model, 20);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone(model, 21));
        }

        [Test]
        public void Test_ChargePhone()
        {
            smartphone = new Smartphone(model, maximumCharge);
            shop.Add(smartphone);
            shop.TestPhone(model, 90);
            shop.ChargePhone(model);

            Assert.That(maximumCharge, Is.EqualTo(smartphone.CurrentBateryCharge));
        }

        [Test]
        public void Test_ChargeNotExistingPhoneShouldThrow()
        {
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("No such Phone"));
        }
    }
}