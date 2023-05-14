using System;
using NUnit.Framework;

namespace RobotFactory.Tests
{
    public class Tests
    {
        private Factory factory;
        Robot robot;

        [SetUp]
        public void Setup()
        {
            factory = new Factory("New Factory", 1000);
            robot = new Robot("Model", 10.0, 5);
            factory.Robots.Add(robot);
        }

        [Test]
        public void ConstructorTest()
        {
            Factory newFactory = new Factory("New Factory", 1000);

            Assert.That(factory.Name, Is.EqualTo("New Factory"));
            Assert.That(factory.Capacity, Is.EqualTo(1000));
            Assert.That(factory.Robots.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements.Count, Is.EqualTo(0));
        }

        [TestCase("Model1", 10.0, 6)]
        [TestCase("Model2", 13.0, 16)]
        [TestCase("Model3", 16.0, 26)]
        public void FactoryProduceRobotCorrectly(string model, double price, int interfaceStandard)
        {
            string result = factory.ProduceRobot(model, price, interfaceStandard);

            Assert.That(factory.Robots.Count, Is.EqualTo(2));
            Assert.That(factory.Robots[1].Model, Is.EqualTo(model));
            Assert.That(factory.Robots[1].Price, Is.EqualTo(price));
            Assert.That(factory.Robots[1].InterfaceStandard, Is.EqualTo(interfaceStandard));
            Assert.That(result, Is.EqualTo($"Produced --> {factory.Robots[1].ToString()}"));
        }

        [Test]
        public void FactoryProduceOverflowCapacityShoudThrow()
        {
            factory.Capacity = 1;

            string result = factory.ProduceRobot("New", 1.0, 1);

            Assert.That(result, Is.EqualTo("The factory is unable to produce more robots for this production day!"));
        }

        [Test]
        public void ProduceSupplementCorrctly()
        {
            string result = factory.ProduceSupplement("Supplement", 10);
            Assert.That(result, Is.EqualTo($"Supplement: Supplement IS: 10"));
            Assert.That(factory.Supplements.Count, Is.EqualTo(1));
            Assert.That(factory.Supplements[0].Name, Is.EqualTo("Supplement"));
            Assert.That(factory.Supplements[0].InterfaceStandard, Is.EqualTo(10));
        }

        [Test]
        public void UpgradeRobotCorrectly()
        {
            Supplement supplement = new Supplement("Supp", 5);

            bool result = factory.UpgradeRobot(robot, supplement);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(1));

        }

        [Test] 
        public void UpgradeRobotFalse()
        {
            Supplement supplement = new Supplement("Supp", 10);

            bool result = factory.UpgradeRobot(robot, supplement);

            Assert.That(result, Is.EqualTo(false));
            Assert.That(factory.Robots[0].Supplements.Count, Is.EqualTo(0));

        }

        [Test]
        public void SellRobot()
        {
            factory = new Factory("factory", 10);

            for (int i = 0; i < 10; i++)
            {
                factory.ProduceRobot(i.ToString(), i, 1);
            }

            Robot soldRobot = factory.SellRobot(6.5);

            Assert.That(soldRobot.Model, Is.EqualTo("6"));

        }
    }
}