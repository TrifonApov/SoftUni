using System;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const int InitialBatteryLevel = 100;

        private string brand;
        private string model;
        private double maxMileage;
        private string licensePlateNumber;
        private int batteryLevel;
        private bool isDamaged;

        public Vehicle(string brand, string model, double maxMileage, string licensePlateNumber)
        {
            Brand = brand;
            Model = model;
            MaxMileage = maxMileage;
            LicensePlateNumber = licensePlateNumber;
            BatteryLevel = InitialBatteryLevel;
            IsDamaged = false;
        }

        public string Brand
        {
            get => brand;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BrandNull);
                }
                brand = value;
            }
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ModelNull);
                }
                model = value;
            }
        }

        public double MaxMileage
        {
            get => maxMileage;
            private set => maxMileage = value;
        }

        public string LicensePlateNumber
        {
            get => licensePlateNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LicenceNumberRequired);
                }
                licensePlateNumber = value;
            }
        }

        public int BatteryLevel
        {
            get => batteryLevel;
            private set => batteryLevel = value;
        }

        public bool IsDamaged
        {
            get => isDamaged;
            private set => isDamaged = value;
        }

        public void Drive(double mileage)
        {
            double percentage = Math.Round((mileage / maxMileage) * 100);
            BatteryLevel -= (int)percentage;

            if (GetType().Name == "CargoVan") BatteryLevel -= 5;
        }

        public void Recharge()
        {
            BatteryLevel = InitialBatteryLevel;
        }

        public void ChangeStatus()
        {
            IsDamaged = !IsDamaged;
        }

        public override string ToString()
        {
            return $"{Brand} {Model} License plate: {LicensePlateNumber} Battery: {BatteryLevel}% Status: {(IsDamaged ? "damaged" : "OK")}";
        }
    }
}