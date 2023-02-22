namespace SoftUniLearningSystem
{
    using System;

    public class Person
    {
        private int age;
        private string firstName;
        private string lastName;


        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("First name is requared and should be at least 2 symbols");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Last name is requared and should be at least 2 symbols");
                }
                this.lastName = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age is requared and should be between 1 and 100");
                }
                this.age = value;
            }
        }
    }
}
