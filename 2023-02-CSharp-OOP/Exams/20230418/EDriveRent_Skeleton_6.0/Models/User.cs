using System;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        private const double InitialRatingsValue = 0;

        private string firstName;
        private string lastName;
        private double rating;
        private string drivingLicenseNumber;
        private bool isBlocked;

        public User(string firstName, string lastName, string drivingLicenceNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            DrivingLicenseNumber = drivingLicenceNumber;
            Rating = InitialRatingsValue;
            IsBlocked = false;
        }

        public string FirstName
        {
            get => firstName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FirstNameNull);
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.LastNameNull);
                }
                lastName = value;
            }
        }

        public string DrivingLicenseNumber
        {
            get => drivingLicenseNumber;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);
                }
                drivingLicenseNumber = value;
            }
        }

        public double Rating
        {
            get => rating;
            private set => rating = value;
        }

        public bool IsBlocked
        {
            get => isBlocked;
            private set => isBlocked = value;
        }

        public void IncreaseRating()
        {
            Rating += 0.5;

            if (Rating > 10.0) Rating = 10.0;
        }

        public void DecreaseRating()
        {
            Rating -= 2.0;

            if (Rating < 0)
            {
                Rating = 0;
                IsBlocked = true;
            }

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} Driving license: {drivingLicenseNumber} Rating: {rating}";
        }
    }
}