namespace Humans.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class Student : Human
    {
        private ulong facultyNumber;

        public Student(string firstName, string lastName, ulong facultyNumber) : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public ulong FacultyNumber
        {
            get { return this.facultyNumber; }
            set
            {
                if (!Regex.IsMatch(value.ToString().PadLeft(5,'0'), "\\d{5,10}"))
                {
                    throw new ArgumentException("Faculty number should be between 5 and 10 digits.");
                }
                this.facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}{2}",
                this.GetType().Name.PadRight(7),
                (this.FirstName + " " + this.LastName).PadRight(25,'-'),
                this.FacultyNumber.ToString().PadLeft(10,'0'));
        }
    }
}