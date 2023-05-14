using NUnit.Framework;
using System;

namespace VehicleGarage.Tests
{
    public class Tests
    {
        private Garage garage;
        private Vehicle vehicle;
        private const int Capacity = 10;
        private const string Brand = "Mazda";
        private const string Model = "6";
        private const string LicensePlate = "CB0801CM";
        private const int Mileage = 350;

        [SetUp]
        public void Setup()
        {
            garage = new Garage(Capacity);
            vehicle = new Vehicle("Mazda", "6", "CB0801CM", Mileage);
        }


        [Test]
        public void ConstructorShouldCreateProperly()
        {
            Assert.That(garage.Capacity, Is.EqualTo(10));
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddVehicleProperly()
        {
            var result = garage.AddVehicle(vehicle);

            Assert.That(result, Is.EqualTo(true));
            Assert.That(garage.Vehicles.Count, Is.EqualTo(1));
            Assert.That(garage.Vehicles[0].Brand, Is.EqualTo(Brand));
            Assert.That(garage.Vehicles[0].Model, Is.EqualTo(Model));
            Assert.That(garage.Vehicles[0].LicensePlateNumber, Is.EqualTo(LicensePlate));

        }

        [Test]
        public void AddVehicleOverCapacity()
        {
            garage.Capacity = 0;

            bool result = garage.AddVehicle(vehicle);

            Assert.False(result);
            Assert.That(garage.Vehicles.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddExistingVehicle()
        {
            bool result = garage.AddVehicle(vehicle);
            bool resultFromExistingVehicle = garage.AddVehicle(vehicle);

            Assert.True(result);
            Assert.False(resultFromExistingVehicle);
        }

        [Test]
        public void ChargeVehicles()
        {
            Vehicle vehicle1 = new Vehicle(Brand, Model, LicensePlate+"1", Mileage);
            Vehicle vehicle2 = new Vehicle(Brand, Model, LicensePlate+"2", Mileage);
            Vehicle vehicle3 = new Vehicle(Brand, Model, LicensePlate+"3", Mileage);
            Vehicle vehicle4 = new Vehicle(Brand, Model, LicensePlate+"4", Mileage);

            vehicle1.BatteryLevel = 99;
            vehicle2.BatteryLevel = 98;
            vehicle3.BatteryLevel = 0;

            garage.AddVehicle(vehicle1);
            garage.AddVehicle(vehicle2);
            garage.AddVehicle(vehicle3);
            garage.AddVehicle(vehicle4);

            int chargedVehicles = garage.ChargeVehicles(99);

            Assert.That(chargedVehicles, Is.EqualTo(3));
            Assert.That(vehicle1.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle2.BatteryLevel, Is.EqualTo(100));
            Assert.That(vehicle3.BatteryLevel, Is.EqualTo(100));
        }

        [Test]
        public void DriveWithoutAccident()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(LicensePlate,20, false);
            
            Assert.That(vehicle.BatteryLevel, Is.EqualTo(80));
            Assert.False(vehicle.IsDamaged);
        }

        [Test]
        public void DriveWithAccident()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(LicensePlate, 20, true);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(80));
            Assert.True(vehicle.IsDamaged);
        }

        [Test]
        public void DriveWithDamagedVehicle()
        {
            vehicle.IsDamaged = true;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(LicensePlate, 20, false);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
        }

        [Test]
        public void DriveWithNotEnoughPower()
        {
            vehicle.BatteryLevel = 50;
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(LicensePlate, 51, false);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(50));
        }

        [Test]
        public void DontDriveWhenDrainageIsMoreThan100()
        {
            garage.AddVehicle(vehicle);
            garage.DriveVehicle(LicensePlate, 101, false);

            Assert.That(vehicle.BatteryLevel, Is.EqualTo(100));
        }

        [Test]
        public void Repair()
        {
            Vehicle newVehicle1 = new Vehicle("1", "1", "1", 100);
            Vehicle newVehicle2 = new Vehicle("2", "2", "2", 100);
            Vehicle newVehicle3 = new Vehicle("3", "3", "3", 100);
            newVehicle1.IsDamaged = true;
            newVehicle2.IsDamaged = true;
            garage.AddVehicle(newVehicle1);
            garage.AddVehicle(newVehicle2);
            garage.AddVehicle(newVehicle3);

            string result = garage.RepairVehicles();

            Assert.False(newVehicle1.IsDamaged);
            Assert.False(newVehicle2.IsDamaged);
            Assert.False(newVehicle3.IsDamaged);
            Assert.That(result, Is.EqualTo("Vehicles repaired: 2"));
        }
    }
}