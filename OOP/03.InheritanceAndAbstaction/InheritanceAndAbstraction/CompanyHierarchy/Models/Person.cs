namespace CompanyHierarchy.Models
{
    using System;

    public abstract class Person
    {
        private int id;
        private string firstName;
        private string lastName;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(value),
                        "Cannot be negative");
                }
                this.id = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "First name cannot null or empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        nameof(value),
                        "Last name cannot null or empty");
                }
                this.firstName = value; this.lastName = value;
            }
        }
    }
}