namespace SoftUniLearningSystem.Students
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : Person
    {
        private double averageGrade;
        private string number;



        public Student(string firstName, string lastName, int age, double avgGrade, string number) 
            : base(firstName, lastName, age)
        {
            this.AverageGrade = avgGrade;
            this.Number = number;
        }

        public string Number
        {
            get { return this.number; }
            set
            {
                if (!Regex.IsMatch(value, "^\\d{10}$"))
                {
                    throw new ArgumentException("Student\'s number should be exactly 10 digits.");
                }
                this.number = value;
            }
        }

        public double AverageGrade
        {
            get { return this.averageGrade; }
            set
            {
                if (value < 2.00 || value > 6.00)
                {
                    throw new ArgumentOutOfRangeException("Average grade should be in range [2.00 - 6.00]");
                }
                this.averageGrade = value;
            }
        }
    }
}