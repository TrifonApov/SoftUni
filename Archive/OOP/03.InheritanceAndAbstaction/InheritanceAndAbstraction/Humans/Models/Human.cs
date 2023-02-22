namespace Humans.Models
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (this.ValidateName(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (this.ValidateName(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                } 
                this.lastName = value;
            }
        }

        private bool ValidateName(string name)
        {
            return string.IsNullOrWhiteSpace(name);
        }
    }
}