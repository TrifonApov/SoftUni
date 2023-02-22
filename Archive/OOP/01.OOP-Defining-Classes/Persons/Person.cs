namespace Persons
{
    using System;
    using System.Text.RegularExpressions;

    public class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age)
            : this (name, age, null)
        {           
        }

        public Person(string name, int age, string email)
        {
            this.Age = age;
            this.Name = name;
            this.Email = email;
        }
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Person should have name different than null or empty string.");
                }
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Person cannot be under 1 or more than 100 years old.");
                }
                this.age = value;
            }
        }

        public string Email
        {
            get { return this.email; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !Regex.IsMatch(value, @"\w{3,}@\w{3,}\.\w{2,}"))
                {
                    throw new ArgumentException("Email is not valid.");
                }
                this.email = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} is {1} years old. Email: {2}", this.name, 
                this.age,
                string.IsNullOrEmpty(this.email) ? "No email" : this.email);
        }

    }
}